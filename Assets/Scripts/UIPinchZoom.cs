using UnityEngine;
using UnityEngine.EventSystems;

public class UIPinchZoom : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    public float zoomSpeed = 0.1f; // �����ٶ�
    private Vector2 originalSize;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // ������������һЩ���ʱ�Ĵ���
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * zoomSpeed);
        }
    }

    void Zoom(float increment)
    {
        rectTransform.sizeDelta += new Vector2(increment, increment);

        // �������������������С��������
        rectTransform.sizeDelta = new Vector2(
            Mathf.Clamp(rectTransform.sizeDelta.x, originalSize.x, originalSize.x * 3),
            Mathf.Clamp(rectTransform.sizeDelta.y, originalSize.y, originalSize.y * 3)
        );
    }
}
