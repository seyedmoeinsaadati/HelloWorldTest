using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform _cardContainer;

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////

    public static Transform CardParent => Instance._cardContainer;

    public static void StartGame()
    {
    }

    public static void GameFinished(bool winner)
    {
        // save profile
        // clear level
    }

    public static void LoadLevel()
    {

    }

    /// </summary>
    /// Clean the playground after finishing level
    /// </summary>
    public static void Clean()
    {
        // TODO: destroy all cards
    }

    // Singleton pattern
    private static Game instance;
    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Game>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<Game>();
                    instance.gameObject.name = instance.GetType().Name;
                }
            }

            return instance;
        }
    }
}
