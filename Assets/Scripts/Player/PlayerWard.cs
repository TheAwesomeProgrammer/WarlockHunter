
using UnityEngine;
public class PlayerWard : CooldownObject
{
    public GameObject WardObject;

    private XboxInput _xboxInput;

    void Start()
    {
        _xboxInput = GetComponent<XboxInput>();
        _xboxInput.OnKeyDown += OnKeyDown;
    }

    void OnKeyDown()
    {
        Instantiate(WardObject, transform.position, Quaternion.identity);
        SetOnCooldown();
    }
}
