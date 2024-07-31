using FlipFlop;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> levels = new();

    private void Awake()
    {
        instance = this;
    }

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////
    public static LevelConfig GetLevel(int levelIndex)
    {
        if (instance != null)
        {
            return instance.levels[levelIndex % instance.levels.Count];
        }

        return null;
    }

    private static Factory instance;

}