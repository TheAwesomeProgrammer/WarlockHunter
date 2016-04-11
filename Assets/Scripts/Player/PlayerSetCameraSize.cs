
using UnityEngine;
public class PlayerSetCameraSize : MonoBehaviour
{
    public const float ProcentExtraBoundary = 30;
    public const float Time = 1;
    public Camera Camera { get; set; }

    void Start()
    {
        Camera = transform.parent.GetComponentInChildren<Camera>();
    }

    public void SetSizeOfCamera(Vector3 size)
    {
        float heightOrtho = size.y / 2;
        float widthOrtho = size.x / heightOrtho;
        float wantedCameraSize = Mathf.Max(heightOrtho, widthOrtho) * (1 + ProcentExtraBoundary / 100);

        LeanTween.value(gameObject, SetCameraSize, Camera.orthographicSize, wantedCameraSize, Time);
    }

    void SetCameraSize(float size)
    {
        Camera.orthographicSize = size;
    }
}
