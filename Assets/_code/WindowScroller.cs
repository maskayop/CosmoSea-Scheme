using UnityEngine;
using UnityEngine.UI;

public class WindowScroller : MonoBehaviour
{
    [SerializeField] RectTransform windowMovable;
    [SerializeField] RectTransform windowScalable;

    [SerializeField] Slider horizontalSlider;
    [SerializeField] float horizontalMultiplier = 1;

    [SerializeField] Slider verticalSlider;
    [SerializeField] float verticalMultiplier = 1;

    [SerializeField] Slider scalerSlider;
    [SerializeField] float minScale = 0.5f;
    [SerializeField] float maxScale = 1.0f;

    void Awake()
    {
        horizontalSlider.value = 0;
        verticalSlider.value = 0;

        scalerSlider.minValue = minScale;
        scalerSlider.maxValue = maxScale;
        scalerSlider.value = 1;
    }

    void Start()
    {
        horizontalSlider.onValueChanged.AddListener(delegate { HorizontalSliderValueChangeCheck(); });
        verticalSlider.onValueChanged.AddListener(delegate { VerticalSliderValueChangeCheck(); });
        scalerSlider.onValueChanged.AddListener(delegate { ScalerSliderValueChangeCheck(); });
    }

    public void HorizontalSliderValueChangeCheck()
    {
        windowMovable.anchorMin = new Vector2 (-horizontalSlider.value * horizontalMultiplier, windowMovable.anchorMin.y);
        windowMovable.anchorMax = new Vector2 (1 - horizontalSlider.value * horizontalMultiplier, windowMovable.anchorMax.y);
    }
    public void VerticalSliderValueChangeCheck()
    {
        windowMovable.anchorMin = new Vector2 (windowMovable.anchorMin.x, verticalSlider.value * verticalMultiplier);
        windowMovable.anchorMax = new Vector2 (windowMovable.anchorMax.x, 1 + verticalSlider.value * verticalMultiplier);
    }

    public void ScalerSliderValueChangeCheck()
    {
        scalerSlider.minValue = minScale;
        scalerSlider.maxValue = maxScale;
        windowScalable.localScale = new Vector3 (scalerSlider.value, scalerSlider.value, scalerSlider.value);
    }
}