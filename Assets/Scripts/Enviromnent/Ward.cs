
using UnityEngine;
public class Ward : ActivateObject
{
    public float Duration = 40;

    private Room _otherRoom;
    private Life _life;

    protected override void Start()
    {
        base.Start();
        _life = GetComponent<Life>();
        _life.DeathEvent += OnDeath;
        ActivateTags.Add("Room");
        Timer.Start(Duration, gameObject, "Die");
    }

    public override void ContinousActivation(GameObject otherObject)
    {
        base.ContinousActivation(otherObject);
        Room otherRoom = otherObject.GetComponent<Room>();
        if (otherRoom != null)
        {
            _otherRoom = otherRoom;
            if (otherRoom.Fog)
            {
                otherRoom.Fog = false;
            }
            
        }
    }

    void OnDeath()
    {
        if (_otherRoom != null)
        {
            _otherRoom.Fog = true;
            _otherRoom = null;
        }
    }

    void Die()
    {
        _life.Health = 0;
    }
}
