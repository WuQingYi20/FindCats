using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;        // 透视模式的缩放速度
    public float orthoZoomSpeed = 0.5f;              // 正交模式的缩放速度

    void Update()
    {
        // 确保同时有两个手指触摸屏幕
        if (Input.touchCount == 2)
        {
            // 获取两个触摸点
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // 获取两个触摸点的上一帧位置
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // 计算两个触摸点之间的旧距离和新距离
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // 计算缩放差
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // 如果这是一个正交相机（Orthographic Camera）
            if (Camera.main.orthographic)
            {
                // 改变相机的正交大小
                Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // 确保相机的大小不会变得过大或过小
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                // 在透视模式下，改变相机的视野
                Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // 确保视野角度在合理范围内
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }
    }
}
