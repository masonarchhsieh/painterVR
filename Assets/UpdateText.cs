using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public Hover.Core.Items.Types.HoverItemDataSelector hoverItemDataSelector;
    public EventsHandler eventsHandler;
    public string status0, status1;
    private int status = 0;
    // Start is called before the first frame update
    void Start()
    {
        status = 0;
    }

    public void ChangeLabel()
    {
        if (eventsHandler.colorpicker_status == 0)
        {
            if (status == 0)
            {
                hoverItemDataSelector.Label = status1;
                status = 1;
            }
            else
            {
                hoverItemDataSelector.Label = status0;
                status = 0;
            }
        }
    }

    public void ColorPickerChangeLabel()
    {
        if (status == 0)
        {
            hoverItemDataSelector.Label = status1;
            status = 1;
        }
        else
        {
            hoverItemDataSelector.Label = status0;
            status = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
