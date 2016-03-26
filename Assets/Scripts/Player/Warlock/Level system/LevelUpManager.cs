using System.Collections.Generic;
using UnityEngine;

public delegate void LevelUpEvent();

public class LevelUpManager : MonoBehaviour
{
    public event LevelUpEvent LevelUpEvent;
    public List<int> XpsToLevel;

    private Warlock _warlock;
    private int _currentLevelUpNumber = 0;

    void Start()
    {
        _warlock = GetComponent<Warlock>();
    }

    // Update is called once per frame
    void Update()
    {
        ShouldLevelUp();
    }

    void ShouldLevelUp()
    {
        if (_warlock.Xp >= XpsToLevel[_currentLevelUpNumber])
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        foreach (var levelUp in GetComponentsInChildren<LevelUp>())
        {
            levelUp.LevelPlayerUp(_currentLevelUpNumber);
        }

        if (LevelUpEvent != null)
        {
            LevelUpEvent.Invoke();
        }

        _warlock.Xp -= XpsToLevel[_currentLevelUpNumber];

        _currentLevelUpNumber++;
    }
}
