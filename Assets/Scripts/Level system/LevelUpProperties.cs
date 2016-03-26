using System;


public delegate void LevelUpEvent(PlayerProperites playerProperites);

[System.Serializable]
public class LevelUpProperties
{
    public int XpToLevel;
    public float Damage;
    public event LevelUpEvent LevelUpEvent;

    public void LevelUp(PlayerProperites playerProperites)
    {
        playerProperites.Damage += Damage;
        if (LevelUpEvent != null)
        {
            LevelUpEvent.Invoke(playerProperites);
        }
    }
}
