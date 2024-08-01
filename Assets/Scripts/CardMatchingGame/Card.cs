using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace FlipFlop
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private Button button;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private AnimationCurve flipCurve = AnimationCurve.Linear(0, 0, 1, 1);

        // based on image (there are only 2 card with same id)
        private int _id = -1;

        // index of card in list
        private int _index = 0;

        private Sprite _sprite;

        private Coroutine _rotatingCoroutine;

        public int Id => _id;
        public int Index => _index;

        private Action<Card> _onClick = null;

        public Card Setup(int index, int id, Sprite sprite)
        {
            _index = index;
            _id = id;
            _sprite = sprite;

            cardImage.sprite = null;
            button.onClick.AddListener(OnCardClicked);

            name = "Card_" + id;
            gameObject.SetActive(true);

            transform.localScale = Vector3.zero;
            this.DoScale(transform, Vector3.one, .3f, .1f * index, flipCurve);

            return this;
        }

        public Card SetOnClick(Action<Card> onClick)
        {
            _onClick = onClick;

            return this;
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
                cardImage.sprite = null;
            });
        }

        private void OnCardClicked()
        {
            _onClick?.Invoke(this);
        }

        private void Destroy()
        {
            this.DoFade(canvasGroup, 0, .2f, .2f, flipCurve);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            button = GetComponent<Button>();
            cardImage = GetComponent<Image>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
#endif
    }
}