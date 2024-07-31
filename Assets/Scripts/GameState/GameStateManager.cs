using FlipFlop;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private State_Playing playing;

    public void Start()
    {
        SetupGamePanel();
    }

    public void SetupGamePanel()
    {
        playing.gameObject.SetActive(true);
        playing.Init();
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