using FlipFlop;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private List<LevelConfig> levels = new();
    [SerializeField] private List<Sprite> cardSprites = new();

    private void Awake()
    {
        instance = this;
    }

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////
    private static Factory instance;

    public static LevelConfig GetLevel(int levelNumber)
    {
        if (instance != null)
        {
            return instance.levels[(levelNumber - 1) % instance.levels.Count];
        }

        return null;
    }

    public static class Sprites
    {
        public static Sprite[] GetSprites(int count)
        {
            int index = 0;
            Sprite[] sprites = new Sprite[count];
            for (int i = 0; i < count; i++)
            {
                sprites[i] = instance.cardSprites[index];
                index++;
            }
            return sprites;
        }
    }
}