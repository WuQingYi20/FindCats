using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomWithScroll : MonoBehaviour, IScrollHandler
{
    private RectTransform rectTransform;
    public float zoomSpeed = 0.5f; // 缩放速度
    public float maxZoom = 2.0f; // 最大缩放倍数
    public float minZoom = 0.5f; // 最小缩放倍数

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        float scroll = eventData.scrollDelta.y;
        rectTransform.localScale += Vector3.one * scroll * zoomSpeed * Time.deltaTime;

        // 限制缩放范围
        rectTransform.localScale = new Vector3(
            Mathf.Clamp(rectTransform.localScale.x, minZoom, maxZoom),
            Mathf.Clamp(rectTransform.localScale.y, minZoom, maxZoom),
            Mathf.Clamp(rectTransform.localScale.z, minZoom, maxZoom)
        );
    }
}
