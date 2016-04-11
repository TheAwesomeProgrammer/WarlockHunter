
using System;
using UnityEngine;
public class XboxInput : MonoBehaviour
{
    public Controls XboxControl;
    public event Action OnKeyDown;

    private XboxControls _xboxControls;
    private PlayerProperties _playerProperties;

    private void Start()
    {
        _xboxControls = XboxControls.instance;
        _playerProperties = GetComponentInParent<Player>().PlayerProperties;
    }

    private void Update()
    {
        if (IsPressedDown() && OnKeyDown != null)
        {
            OnKeyDown();
        }
    }

    private bool IsPressedDown()
    {
        return _xboxControls.UserPressedButton(XboxControl, _playerProperties.ControllerNumber);
    }
  

}
