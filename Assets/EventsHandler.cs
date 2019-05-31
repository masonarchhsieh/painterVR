using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class EventsHandler : MonoBehaviour
{
    public Camera leap_camera;
    public GameObject colorPicker;
    public GameObject plane;
    public Leap.Unity.LeapImageRetriever leapImageRetriever;
    public int background_status = 0;
    public int colorpicker_status = 0;
    // Start is called before the first frame update
    void Start()
    {
        colorPicker.SetActive(false);
        colorpicker_status = 1;

        leap_camera.clearFlags = CameraClearFlags.Skybox;
        leapImageRetriever.enabled = false;
        background_status = 0;
    }

    public void ChangeColorPickerStatus()
    {
        switch (colorpicker_status)
        {
            case 0:
                colorPicker.SetActive(false);
                colorpicker_status++;
                break;
            case 1:
                colorPicker.SetActive(true);
                colorpicker_status = 0;
                break;
            default:
                colorPicker.SetActive(true);
                colorpicker_status = 0;
                break;
        }
    }

    public void ChangeBackground()
    {
        switch (background_status) {
            case 0:
                leap_camera.clearFlags = CameraClearFlags.SolidColor;
                leapImageRetriever.enabled = true;
                plane.SetActive(false);
                background_status++;
                break;
            case 1:
                leap_camera.clearFlags = CameraClearFlags.Skybox;
                leapImageRetriever.enabled = false;
                plane.SetActive(true);
                background_status = 0;
                break;
            default:
                leap_camera.clearFlags = CameraClearFlags.Skybox;
                leapImageRetriever.enabled = false;
                plane.SetActive(true);
                background_status = 0;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeBackground();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeColorPickerStatus();
        }
    }
}
