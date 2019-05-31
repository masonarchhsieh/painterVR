 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class DrawLineManager : MonoBehaviour
{
    public Material lMat;
    public ColorManager colorManager;
    public LineManager lineManager;

    public Transform index_transform;
    public Leap.Unity.PinchDetector pinchDetector;

    private MeshLineRenderer currLine;
    private int numClicks = 0;
    private float lineWidth = .05f;
    private int reset = 0;
    private int undo = 0;
    private int hover_status = 0;   // 0: free, 1: busy -> can't draw
    // Testing Undo Feature
    private List<GameObject> drawing_list = new List<GameObject>();
    private List<MeshLineRenderer> in_game_go_objects = new List<MeshLineRenderer>();
    private List<MeshLineRenderer> game_objects_from_rpc = new List<MeshLineRenderer>();

    public void GrabColorPicker()
    {
        hover_status = 1;
    }

    public void ReleaseColorPicker()
    {
        hover_status = 0;
    }
   

    public void CallUndo()
    {
        undo++;
    }

    public void CallReset()
    {
        reset = 1;
    }

    public void SetMaterial(Material mat)
    {
        currLine.lmat = mat;
    }

    // Start is called before the first frame update
    void Start()
    {
        //set up the photon sendrate
        // PhotonNetwork.sendRate = 20;
        // PhotonNetwork.sendRateOnSerialize = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (hover_status == 0)
        {
            if (pinchDetector.DidStartPinch)
            {
                GameObject go = new GameObject();
                go.AddComponent<MeshFilter>();
                go.AddComponent<MeshRenderer>();
                currLine = go.AddComponent<MeshLineRenderer>();

                in_game_go_objects.Add(currLine);
                drawing_list.Add(go);

                currLine.lmat = new Material(lMat);
                currLine.SetWidth(lineManager.lineWidth);
            }
            // If it is still pinching
            else if (pinchDetector.IsPinching)
            {
                currLine.AddPoint(index_transform.position);
            }
            else if (pinchDetector.DidEndPinch)
            {
                // We should synchronize the latest created object to the server
                // PhotonNetwork.Instantiate("MeshLineRenderer", currLine.transform.position, currLine.transform.rotation, 0);
                currLine = null;
            }
        }
        else
        {
            currLine = null;
        }
        // If undo is call, destroy the latest drawing
        if (undo > 0)
        {
            if (drawing_list.Count > 0)
            {
                GameObject tempO = drawing_list[drawing_list.Count - 1];
                drawing_list.RemoveAt(drawing_list.Count - 1);
                Destroy(tempO);

                undo--;
            }
            else if (drawing_list.Count == 0)
            {
                undo = 0;
            }
        }

        // If reset is call, destroy all the drawing
        if (reset == 1)
        {
            //foreach (MeshLineRenderer temp in in_game_go_objects)
            //{
            //    temp.ClearMesh();
            //    in_game_go_objects.Remove(temp);
            //}

            int size = drawing_list.Count;
            for (int i = size - 1; i >=  0; i--)
            {
                GameObject tempO = drawing_list[i];
                drawing_list.RemoveAt(i);
                Destroy(tempO);
            }
            reset = 0;
        }
        // Color Manager && Line Manager
        if (currLine != null)
        {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor();
            currLine.SetWidth(lineManager.lineWidth);
        }
    }


    // For PunPC
    [PunRPC]
    void MyRemoteMethod(MeshLineRenderer remoteMeshLineRenderer)
    {
        Debug.Log("CatCH Call this method");
        game_objects_from_rpc.Add(remoteMeshLineRenderer);
    }
}
