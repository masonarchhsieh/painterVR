using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hover;
using Hover.Core.Items.Types;
using Hover.Core.Renderers;
using Hover.Core.Renderers.Items.Buttons;
using Hover.Core.Renderers.Items.Sliders;
using Hover.Core.Utils;
using Hover.RendererModules.Alpha;


public class ChangeColorManager : MonoBehaviour
{
    public HoverAlphaMeshUpdater segmentA, segmentB, segmentC, segmentD;
    public ColorIndicator colorIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Color temp = colorIndicator.GetCurrentColour();
        //Color fadedColor = DisplayUtil.FadeColor(temp, 0.5f);
        //segmentB.StandardColor = fadedColor;
        //segmentB.SliderFillColor = fadedColor;
    }
    private void UpdateTrackColor(Color pColor)
    {
        HoverFillSlider fill = GetComponentInChildren<HoverFillSlider>();
        Color fadedColor = DisplayUtil.FadeColor(pColor, 0.25f);
        UpdateTrackSegmentColor(fill.SegmentA, fadedColor);
        UpdateTrackSegmentColor(fill.SegmentB, fadedColor);
        UpdateTrackSegmentColor(fill.SegmentC, fadedColor);
        UpdateTrackSegmentColor(fill.SegmentD, fadedColor);
    }

    private void UpdateTrackSegmentColor(HoverMesh pMesh, Color pColor)
    {
        HoverAlphaMeshUpdater alphaUp = pMesh.GetComponent<HoverAlphaMeshUpdater>();
        alphaUp.StandardColor = pColor;
        alphaUp.SliderFillColor = pColor;
    }
}
