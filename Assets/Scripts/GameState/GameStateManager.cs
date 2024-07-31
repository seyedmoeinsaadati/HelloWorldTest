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
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        mainMenu.Show();
        mainMenu.Init();

        playing.Hide();
        lose.Hide();
        win.Hide();
    }

    public void OpenGamePanel()
    {
        playing.Show();

        mainMenu.Hide();
        lose.Hide();
        win.Hide();
    }

    public void OpenWinPanel()
    {
        win.Show();

        playing.Hide();
        lose.Hide();
        mainMenu.Hide();
    }

    public void OpenLosePanel()
    {
        lose.Show();

        playing.Hide();
        win.Hide();
        mainMenu.Hide();
    }
}