using FlipFlop;
using UnityEngine;

public class CardMatchingGameHandler : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform _cardContainer;
    [SerializeField] private Card _cardPrefab;

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////

    public static Transform CardParent => Instance._cardContainer;

    public static void StartGame()
    {
        GameInfo.Reset();

        GameStateManager.Instance.OpenGamePanel();


        GameInfo.levelNumber = PlayerProfile.LevelIndex;
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
    private static CardMatchingGameHandler instance;
    public static CardMatchingGameHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CardMatchingGameHandler>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<CardMatchingGameHandler>();
                    instance.gameObject.name = instance.GetType().Name;
                }
            }

            return instance;
        }
    }
}
