
using UnityEngine;
public class PlayerMoveCamera : MonoBehaviour
{
    public float Time;
    public LeanTweenType LeamTweenType;
    public Transform Camera { get; set; }

    private Transform _cameraParent;

    void Start()
    {
        Camera = transform.parent.GetComponentInChildren<Camera>().transform;
        _cameraParent = Camera.parent;
    }

    public void Move(Vector2 position)
    {
        if (LeanTween.isTweening(Camera.gameObject))
        {
            Pause();
        }
        LeanTween.move(Camera.gameObject, position, Time).setEase(LeamTweenType);
    }

    public void Pause()
    {
        LeanTween.cancel(Camera.gameObject);
    }
}
