using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Button button;

        private int id = -1; // based on image (there are only 2 card with same id)
        private int index = 0; // index of card in list

        private Sprite sprite;

        public void Setup(int index, int id, Sprite sprite)
        {
            this.index = index;
            this.id = id;
            name = "Card_" + id;
            cardImage.sprite = null;

            button.onClick.AddListener(OnCardClicked);

            gameObject.SetActive(true);
        }

        private void OnCardClicked()
        {
            // CardMatchingGameHandler.PickCard(id);
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