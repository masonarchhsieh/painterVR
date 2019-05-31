using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hover;
using Hover.Core.Items.Types;
using Hover.RendererModules.Alpha;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    public Material lmat;
    private Color color;
    public HoverItemDataSlider colorDataSelector, brightnessDataSelector;
    // public HoverAlphaMeshUpdater segmentA, segmentB, segmentC, segmentD;
    public ColorHuePicker colorHuePicker;
    public ColorSaturationBrightnessPicker csbp;

    // Start is called before the first frame update
    void Start()
    {
        this.color = lmat.color;
    }

    public void SelectColorOnColorPicker()
    {
        float degree = (float)colorDataSelector.RangeValue;
        colorHuePicker.SetColorFromHoverMenu(degree);
    }

    public void SelectBrightnessOnColorPicker()
    {
        float degree = (float)brightnessDataSelector.RangeValue;
        colorHuePicker.SetBrightnessFromHoverMenu(degree);
    }

    public Material GetCurrentMaterial()
    {
        return this.lmat;
    }

    void OnColorChange(HSBColor color)
    {
        this.color = color.ToColor();
    }

    public Color GetCurrentColor()
    {
        return this.color;
    }

    public void OnMaterialChange(Material mat)
    {
        Instance.color = mat.color;
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

}
