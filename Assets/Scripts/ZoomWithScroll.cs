using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomWithScroll : MonoBehaviour, IScrollHandler
{
    private RectTransform rectTransform;
    public float zoomSpeed = 0.5f; // �����ٶ�
    public float maxZoom = 2.0f; // ������ű���
    public float minZoom = 0.5f; // ��С���ű���

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        float scroll = eventData.scrollDelta.y;
        rectTransform.localScale += Vector3.one * scroll * zoomSpeed * Time.deltaTime;

        // �������ŷ�Χ
        rectTransform.localScale = new Vector3(
            Mathf.Clamp(rectTransform.localScale.x, minZoom, maxZoom),
            Mathf.Clamp(rectTransform.localScale.y, minZoom, maxZoom),
            Mathf.Clamp(rectTransform.localScale.z, minZoom, maxZoom)
        );
    }
}
