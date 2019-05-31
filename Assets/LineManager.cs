using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hover;
using Hover.Core.Items.Types;

public class LineManager : MonoBehaviour
{
    private float unit = .001f;
    public float lineWidth = (float) .05f;
    private float previous = (float) .05f;
    public HoverItemDataSlider itemDataSelector;

    public void SetPreviousWidth()
    {
        float temp = this.lineWidth;
        this.lineWidth = previous;
        this.previous = temp;
        itemDataSelector.Value = (lineWidth / unit);
    }

    public void OnWidthChange()
    {
        this.previous = lineWidth;
        this.lineWidth = (itemDataSelector.RangeValue * unit);
    }

    public void ResetWidth()
    {
        this.previous = lineWidth;
        this.lineWidth = (float) .05f;
        itemDataSelector.Value =  (float) (lineWidth / unit);
    }

    // Start is called before the first frame update
    void Start()
    {
    }
}
