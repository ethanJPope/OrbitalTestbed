using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public RectTransform tooltipPanel;
    public TMP_Text tooltipText;
    void Awake()
    {
        Instance = this;
        tooltipPanel.gameObject.SetActive(false);
    }
    void Update()
    {
        // if (tooltipPanel.gameObject.activeSelf)
        // {
        //     Vector2 position;
        //     RectTransformUtility.ScreenPointToLocalPointInRectangle(
        //         tooltipPanel.parent as RectTransform,
        //         Input.mousePosition,
        //         null,
        //         out position);
        //     tooltipPanel.localPosition = position + new Vector2(10f, -10f);
        // }
    }

    public void ShowTooltip(string text)
    {
        tooltipText.text = text;
        tooltipPanel.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.gameObject.SetActive(false);
    }
}
