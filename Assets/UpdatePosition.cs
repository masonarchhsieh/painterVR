using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class UpdatePosition : MonoBehaviour
{
    Vector3 palmL_position;
    public Vector3 colab;
    public Quaternion colab_Rotation;
    public Camera leap_camera;
    public HandModel hand_L;
    public int lHand_status = 0;    // 0: means inactive, 1: active
    public EventsHandler eventsHandler;

    private Vector3 initial_position;
    public void Init()
    {
        initial_position = new Vector3(-10, -10, -10);
        lHand_status = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_position = new Vector3(-10,-10,-10);
        lHand_status = 1;
    }

    public void LeftHandUp()
    {
        if (lHand_status != 2)
            lHand_status = 1;
    }

    public void Detach()
    {
        if (eventsHandler.colorpicker_status == 0)
        {
            if (lHand_status == 1)
                lHand_status = 2;
            else if (lHand_status == 2)
                lHand_status = 1;
        }
    }

    public void LeftHandDown()
    {
        if (lHand_status != 2)
            lHand_status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hand_L.IsTracked && lHand_status == 1)
        {
            palmL_position = hand_L.GetWristPosition();
            //Vector3 temp = hand_L.GetPalmRotation() * colab;
            Vector3 temp = leap_camera.transform.rotation * colab;
            transform.position = palmL_position + temp;
            transform.rotation = leap_camera.transform.rotation;
        }
        else if (lHand_status == 2)
        {
            //do nothing
        }
        else if (lHand_status == 0)
        {
            transform.position = initial_position;
        }
        
    }
}
