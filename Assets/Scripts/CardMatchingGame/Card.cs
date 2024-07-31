using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Button button;

        private int id = -1;

        public void Setup(int id, Sprite sprite)
        {
            this.id = id;
            name = "Card_" + id;
            cardImage.sprite = sprite;

            button.onClick.AddListener(OnCardClicked);

            gameObject.SetActive(true);
        }

        public void OnCardClicked()
        {
            // TODO: ...
        }

        public void FlipUp()
        {

        }

        public void FlipDown()
        {

        }


#if UNITY_EDITOR
        private void Reset()
        {
            button = GetComponent<Button>();
            cardImage = GetComponent<Image>();
        }
#endif
    }
}