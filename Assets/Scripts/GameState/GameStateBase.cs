using UnityEngine;

namespace FlipFlop
{
    public abstract class GameStateBase : MonoBehaviour
    {
        public abstract void Init();

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}