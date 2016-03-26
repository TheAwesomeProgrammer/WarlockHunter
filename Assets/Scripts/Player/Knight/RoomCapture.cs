
using UnityEngine;

public class RoomCapture : MonoBehaviour
{
    public float Cooldown;
    public float Duration;

    private XboxInput _xboxInput;
    private Player _player;

    private bool _canCapture = true;
 
    void Start()
    {
        _xboxInput = GetComponent<XboxInput>();
        _player = GetComponentInParent<Player>();
    }

    void Update()
    {
        if (_xboxInput.IsPressedDown() && _canCapture)
        {
            _canCapture = false;
            _player.CurrentRoom.Captured = true;
            Timer.Start(Cooldown, gameObject, "CaptureAgain");
            Timer.Start(Duration, gameObject, "Deactivate");
        }
    }

    void Deactivate()
    {
        _player.CurrentRoom.Captured = false;
    }

    void CaptureAgain()
    {
        _canCapture = true;
    }
}
