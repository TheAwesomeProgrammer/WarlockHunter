using UnityEngine;


public class WarlockPukeDamager : WarlockAbillityDamager
{
    public float PukeInterval = 1;

    protected override void Start()
    {
        base.Start();
        UpdatePuke();
    }

    private void UpdatePuke()
    {
        Timer.Start(PukeInterval, gameObject, "UpdatePuke");
        _objectsDoneDamageTo.Clear();
    }
}
