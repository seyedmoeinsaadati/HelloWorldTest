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

    public static LevelConfig GetLevel(int levelIndex)
    {
        if (instance != null)
        {
            return instance.levels[levelIndex % instance.levels.Count];
        }

        return null;
    }

    public static class Sprites
    {
        public static Sprite[] GetSprites(int size)
        {
            int index = 0;
            Sprite[] sprites = new Sprite[size];
            for (int i = 0; i < size; i += 2)
            {
                sprites[i] = instance.cardSprites[index];
                sprites[i + 1] = instance.cardSprites[index];
                index++;
            }
            return Shuffle(sprites);
        }

        private static T[] Shuffle<T>(T[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                T temp = list[i];
                int randomIndex = Random.Range(i, list.Length - 1);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
            return list;
        }
    }


}