using FlipFlop;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private State_Main mainMenu;
    [SerializeField] private State_Playing playing;
    [SerializeField] private State_Win win;
    [SerializeField] private State_Lose lose;


    private void Start()
    {
        SetupMainMenu();
    }

    public void SetupMainMenu()
    {
        mainMenu.Show();
        mainMenu.Init();

        playing.Hide();
        lose.Hide();
        win.Hide();
    }

    public void SetupGamePanel()
    {
        playing.Show();
        playing.Init();

        mainMenu.Hide();
        lose.Hide();
        win.Hide();
    }

    public void WinGame()
    {
        win.Show();
        win.Init();

        playing.Hide();
        lose.Show();
        mainMenu.Hide();
    }

    public void LoseGame()
    {
        lose.Show();
        lose.Init();

        playing.Hide();
        win.Show();
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