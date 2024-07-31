using FlipFlop;
using UnityEngine;

public class CardMatchingGameHandler : MonoBehaviour
{
    [Space]
    [SerializeField] private GameStateManager gameManager;
    [SerializeField] private Transform _cardContainer;
    [SerializeField] private Card _cardPrefab;

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////

    public static Transform CardParent => Instance._cardContainer;

    public static void StartGame()
    {
        GameInfo.Reset();

        Instance.gameManager.OpenGamePanel();

        GameInfo.levelNumber = PlayerProfile.LevelIndex;

        LoadLevel();
        Instance.gameManager.OpenGamePanel();
    }
    public static void Win()
    {
        Clean();
        PlayerProfile.LevelIndex++;
        Instance.gameManager.OpenWinPanel();
    }

    public static void Lose()
    {
        Instance.gameManager.OpenLosePanel();
    }

    public static void BackToMainMenu()
    {
        Instance.gameManager.OpenMainMenu();
    }


    public static void LoadLevel()
    {
        var config = Factory.GetLevel(GameInfo.levelNumber);
        GameInfo.time = config.timeLimit;

        // spawn cards

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
