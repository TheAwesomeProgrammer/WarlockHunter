using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Level_system;

public class XboxMovement : MonoBehaviour
{
    public int ControllerNumber = 0;

    private XboxControls _xboxControls;
    private PlayerProperites _playerProperites;

	// Use this for initialization
	void Start () {
        _xboxControls = XboxControls.instance;
	    _playerProperites = GetComponent<Player>().PlayerProperites;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Move();
	}

    void Move()
    {
        transform.Translate(_xboxControls.ThumbStick(Controls.LeftStick, ControllerNumber) * _playerProperites.Speed * Time.deltaTime);
    }
}
