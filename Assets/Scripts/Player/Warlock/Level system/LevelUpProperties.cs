using System;


[System.Serializable]
public class LevelUpProperties
{
    public int Damage;

    public void LevelUp(PlayerProperties playerProperties)
    {
        playerProperties.Damage += Damage;
    }

    public void LevelUp(WarlockAbillityProperties warlockAbillityProperties)
    {
        warlockAbillityProperties.Damage += Damage;
    }
}
