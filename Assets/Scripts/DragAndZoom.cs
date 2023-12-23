using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndZoom : MonoBehaviour, IDragHandler, IPointerDownHandler, IScrollHandler
{
    private RectTransform rectTransform;
    private Vector2 originalSize;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 重置点击时的锚点位置
        rectTransform.SetAsLastSibling();
    }

    public void OnScroll(PointerEventData eventData)
    {
        float zoomFactor = 0.1f;
        rectTransform.sizeDelta += eventData.scrollDelta * zoomFactor;

        // 限制缩放大小
        rectTransform.sizeDelta = new Vector2(
            Mathf.Clamp(rectTransform.sizeDelta.x, originalSize.x, originalSize.x * 2),
            Mathf.Clamp(rectTransform.sizeDelta.y, originalSize.y, originalSize.y * 2)
        );
    }
}
