using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.ShowTooltip(description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.HideTooltip();
    }
}
