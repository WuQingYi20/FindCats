using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;        // ͸��ģʽ�������ٶ�
    public float orthoZoomSpeed = 0.5f;              // ����ģʽ�������ٶ�

    void Update()
    {
        // ȷ��ͬʱ��������ָ������Ļ
        if (Input.touchCount == 2)
        {
            // ��ȡ����������
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // ��ȡ�������������һ֡λ��
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // ��������������֮��ľɾ�����¾���
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // �������Ų�
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // �������һ�����������Orthographic Camera��
            if (Camera.main.orthographic)
            {
                // �ı������������С
                Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // ȷ������Ĵ�С�����ù�����С
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                // ��͸��ģʽ�£��ı��������Ұ
                Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // ȷ����Ұ�Ƕ��ں���Χ��
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
