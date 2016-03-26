using UnityEngine;

public class RangerAttack : MonoBehaviour
{
    public GameObject Arrow;
    public Transform ShootTransform;

    private PlayerProperties _playerProperties;
    private XboxControls _xboxControls;
    private PlayerFlip _playerFlip;

    private bool _canShoot = true;

    void Start()
    {
        _xboxControls = XboxControls.instance;
        _playerProperties = GetComponent<Player>().PlayerProperties;
        _playerFlip = GetComponent<PlayerFlip>();
    }

    void Update()
    {
        SetFlipping();
        if (_canShoot && _xboxControls.UserPressedButton(Controls.RT, _playerProperties.ControllerNumber))
        {
            Shoot();
        }
    }

    void SetFlipping()
    {
        _playerFlip.ShouldFlip(transform, _xboxControls.ThumbStick(Controls.RightStick, _playerProperties.ControllerNumber),
            _playerProperties.FlippedStart);
    }

    void Shoot()
    {
        Vector2 shootDirection = _xboxControls.ThumbStick(Controls.RightStick, _playerProperties.ControllerNumber).normalized;
        GameObject spawnedObject = Instantiate(Arrow, ShootTransform.position, Quaternion.Euler(new Vector3(0, 0, shootDirection.GetAngleBasedOnDirection()))) as GameObject;
        spawnedObject.GetComponent<Shot>().Damage = _playerProperties.Damage;
        StopShooting();
    }

    void StopShooting()
    {
        _canShoot = false;
        Timer.Start(_playerProperties.AttackSpeed, gameObject, "StartShooting");
    }

    void StartShooting()
    {
        _canShoot = true;
    }
}
