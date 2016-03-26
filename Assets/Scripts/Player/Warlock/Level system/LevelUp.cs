using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelUp : MonoBehaviour
{
    public List<LevelUpProperties> LevelUpPropertieses = new List<LevelUpProperties>();
    private WarlockAbillityProperties _warlockAbillityProperties;
    private Warlock _warlock;

	// Use this for initialization
	void Start ()
	{
	    if (GetComponent<WarlockAbillity>() != null)
	    {
            _warlockAbillityProperties = GetComponent<WarlockAbillity>().WarlockAbillityProperties;
	    }
	    if (GetComponent<Warlock>() != null)
	    {
            _warlock = GetComponent<Warlock>();
        }
	}

    public void LevelPlayerUp(int level)
    {
        LevelUpProperties levelUpProperties = LevelUpPropertieses[level];
        levelUpProperties.LevelUp(_warlock.PlayerProperties);
        levelUpProperties.LevelUp(_warlockAbillityProperties);
    }
}
