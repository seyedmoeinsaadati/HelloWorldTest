using FlipFlop;
using UnityEngine;

public class CardMatchingGame : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform _cardContainer;

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////

    public static Transform CardParent => Instance._cardContainer;

    public static void StartGame()
    {
        GameInfo.Reset();

        GameStateManager.Instance.OpenGamePanel();

        // load level
        // load game board
        // start game
    }

    public static void GameFinished(bool winner)
    {
        Clean();

        if (winner)
        {
            PlayerProfile.LevelIndex++;
            GameStateManager.Instance.OpenWinPanel();
        }
        else
        {
            GameStateManager.Instance.OpenLosePanel();
        }
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
    private static CardMatchingGame instance;
    public static CardMatchingGame Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CardMatchingGame>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<CardMatchingGame>();
                    instance.gameObject.name = instance.GetType().Name;
                }
            }

            return instance;
        }
    }
}
