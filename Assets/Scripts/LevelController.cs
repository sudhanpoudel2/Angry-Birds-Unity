using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;

    Monster[] _monster;


    void OnEnable()
    {
        _monster = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (MonsterAreAllDead())
            GoToNextLevel();
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName); 
    }

    bool MonsterAreAllDead()
    {
        foreach (Monster monster in _monster)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}
