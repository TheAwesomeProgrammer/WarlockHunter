using UnityEngine;

public class DecreaseSpeed : MonoBehaviour
{
    public float ProcentDecrease;

    private Shot _shot;

    void Start()
    {
        _shot = GetComponent<Shot>();
        ProcentDecrease /= 100;
    }

    void Update()
    {
        _shot.Speed -= (_shot.Speed*ProcentDecrease);
    }
}

   
