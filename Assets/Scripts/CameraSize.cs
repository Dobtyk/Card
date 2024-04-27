using UnityEngine;

public class CameraSize : MonoBehaviour
{
    const float TargetSizeX = 1920f;
    const float TargetSizeY = 1080f;
    const float HalfSize = 200f; // Половина высоты в пикселях

    void Awake()
    {
        CameraResize();
    }

    void CameraResize()
    {
        var screenRatio = (float)Screen.width / Screen.height;
        var targetRatio = TargetSizeX / TargetSizeY;

        if (screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            var differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    void Resize(float differentSize = 1f)
    {
        Camera.main.orthographicSize = TargetSizeY / HalfSize * differentSize;
    }
}