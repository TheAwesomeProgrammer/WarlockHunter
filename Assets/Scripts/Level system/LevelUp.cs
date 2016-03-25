using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelUp : MonoBehaviour
{

    public List<LevelUpProperties> LevelUpPropertieses = new List<LevelUpProperties>();
    private PlayerProperites _playerProperites;

    private int _currentLevelUpNumber = 0;
	// Use this for initialization
	void Start ()
	{
	    _playerProperites = GetComponent<PlayerProperites>();

	}
	
	// Update is called once per frame
	void Update () {
	  ShouldLevelUp();
	}

    void ShouldLevelUp()
    {
        if (_playerProperites.Xp >= LevelUpPropertieses[_currentLevelUpNumber].XpToLevel)
        {
            LevelPlayerUp();
        }
    }

    void LevelPlayerUp()
    {
        LevelUpProperties levelUpProperties = LevelUpPropertieses[_currentLevelUpNumber];
        _playerProperites.Xp -= levelUpProperties.XpToLevel;
        _playerProperites.Damage += levelUpProperties.Damage;
    }
}
