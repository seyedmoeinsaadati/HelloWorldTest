using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class UiSoundButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(PlayClickSound);
        }

        private void PlayClickSound()
        {
            AudioEventHandler.PlayUiClick();
        }

#if UNITY_EDITOR
        private void Reset()
        {
            button = GetComponent<Button>();
        }
#endif

    }
}