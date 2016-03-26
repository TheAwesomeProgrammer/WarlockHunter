using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;

public class XboxMovement : Movement
{
    private XboxControls _xboxControls;
    private PlayerProperties _playerProperties;
    private PlayerFlip _playerFlip;
    private Collision _collision;
    private Life _life;

	// Use this for initialization
	protected override void Start () {
        _xboxControls = XboxControls.instance;
	    _playerProperties = GetComponent<Player>().PlayerProperties;
        _playerFlip = GetComponent<PlayerFlip>();
	    _collision = GetComponentInChildren<Collision>();
	    _life = GetComponent<Life>();

	}

    // Update is called once per frame
    protected override void Update ()
	{
        base.Update();
        SetFlipped();
    }

    void SetFlipped()
    {
        _playerFlip.ShouldFlip(transform, _xboxControls.ThumbStick(Controls.LeftStick, _playerProperties.ControllerNumber),
            _playerProperties.FlippedStart);
    }

    protected override void Move()
    {
        Vector2 velocity = _xboxControls.ThumbStick(Controls.LeftStick, _playerProperties.ControllerNumber).normalized *
            _playerProperties.Speed * Time.deltaTime;

        Vector2 allowedPosition = _collision.GetAllowedPosition(transform.position,
            (Vector2)transform.position + velocity, GetComponent<Collider2D>().bounds.extents, gameObject);
        transform.Translate(allowedPosition - (Vector2)transform.position, Space.World);
    }
}
