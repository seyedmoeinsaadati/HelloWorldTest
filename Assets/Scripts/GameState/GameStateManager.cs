using FlipFlop;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private State_Main mainMenu;
    [SerializeField] private State_Playing playing;

    private void Start()
    {
        SetupMainMenu();
    }

    public void SetupMainMenu()
    {
        mainMenu.Show();
        mainMenu.Init();

        playing.Hide();
    }

    public void SetupGamePanel()
    {
        playing.Show();
        playing.Init();

        mainMenu.Hide();
    }

    ///////////////////////////////////////
    /// STATIC MEMEBERS
    ///////////////////////////////////////

    // Singleton pattern
    private static GameStateManager instance;

    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameStateManager>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<GameStateManager>();
                    instance.gameObject.name = instance.GetType().Name;
                }
            }

            return instance;
        }
    }
}