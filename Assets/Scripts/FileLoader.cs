using FlipFlop;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour
{
    [SerializeField] private List<Level> levels = new();

    private void Awake()
    {
        instance = this;
    }

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////
    public static Level GetLevel(int levelIndex)
    {
        if (instance != null)
        {
            return instance.levels[levelIndex % instance.levels.Count];
        }

        return null;
    }

    private static FileLoader instance;

}