using UnityEngine;
using UnityEngine.UI;
using Utils;
using static Factory;

namespace FlipFlop
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Button button;

        [SerializeField] private AnimationCurve flipCurve = AnimationCurve.Linear(0, 0, 1, 1);

        // based on image (there are only 2 card with same id)
        private int _id = -1;

        // index of card in list
        private int _index = 0;

        private Sprite _sprite;

        private Coroutine _rotatingCoroutine;

        public int Id => _id;
        public int Index => _index;

        public void Setup(int index, int id, Sprite sprite)
        {
            _index = index;
            _id = id;
            _sprite = sprite;

            cardImage.sprite = null;
            button.onClick.AddListener(OnCardClicked);

            name = "Card_" + id;
            gameObject.SetActive(true);
        }

        private void OnCardClicked()
        {
            // CardMatchingGameHandler.PickCard(id);
        }

        public void FlipUp()
        {
            // TODO: Play sound

            if (_rotatingCoroutine != null) StopCoroutine(_rotatingCoroutine);
            _rotatingCoroutine = this.DORotation(transform, new Vector3(0, 180, 0), .5f, .1f, flipCurve,
            OnComplete: () =>
            {
                cardImage.sprite = _sprite;
            });
        }

        public void FlipBack()
        {
            // TODO: Play sound

            if (_rotatingCoroutine != null) StopCoroutine(_rotatingCoroutine);
            _rotatingCoroutine = this.DORotation(transform, new Vector3(0, 0, 0), .5f, .1f, flipCurve,
            OnComplete: () =>
            {
                button.image.sprite = null;
            });
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