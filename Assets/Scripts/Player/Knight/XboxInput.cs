
using UnityEngine;
public class XboxInput : MonoBehaviour
{
    public Controls XboxControl;

    private XboxControls _xboxControls;
    private PlayerProperties _playerProperties;

    private void Start()
    {
        _xboxControls = XboxControls.instance;
        _playerProperties = GetComponentInParent<Player>().PlayerProperties;
    }

    public bool IsPressedDown()
    {
        return _xboxControls.UserPressedButton(XboxControl, _playerProperties.ControllerNumber);
    }
  

}
