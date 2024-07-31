using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Main : GameStateBase
    {
        [SerializeField] private Button playButton;

        public override void Init()
        {
            playButton.onClick.AddListener(StartGame);
        }

        public void StartGame()
        {
            // ...
        }

    }
}