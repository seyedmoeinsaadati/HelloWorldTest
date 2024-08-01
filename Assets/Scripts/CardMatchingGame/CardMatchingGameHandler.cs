using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlipFlop
{
    public partial class CardMatchingGameHandler : MonoBehaviour
    {
        [Space]
        [SerializeField] private GameStateManager gameManager;
        [SerializeField] private Transform _cardContainer;
        [SerializeField] private Card _cardPrefab;

        private float _lastCorrectTime = 0;

        private void Awake()
        {
            _cardPrefab.gameObject.SetActive(false);

            _FirstGuess = new();
            _SecondGuess = new();
        }

        private void LoadLevel()
        {
#if UNITY_EDITOR
            Debug.Log($"Level: {GameInfo.levelNumber}");
            Debug.Log($"Card Counts: {_Config.numCard}");
            Debug.Log($"Level Time: {_Config.timeLimit}");
#endif

            // spawn cards
            _Cards.Clear();

            int spriteCount = _Config.numCard / 2;

            Sprite[] cardSprites = Factory.Sprites.GetSprites(spriteCount);
            for (int id = 0, index = 0; id < spriteCount; id++)
            {
                var card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(index, id, cardSprites[id])
                        .SetOnClick(PickCard);

                    _Cards.Add(card);
                    index++;
                }

                card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(index, id, cardSprites[id])
                        .SetOnClick(PickCard);

                    _Cards.Add(card);
                    index++;
                }
            }

            // shuffle cards
            foreach (var card in _Cards)
            {
                card.transform.SetSiblingIndex(UnityEngine.Random.Range(0, _Cards.Count));
            }
        }

        private void Clean()
        {
            for (int i = 0; i < _Cards.Count; i++)
                Destroy(_Cards[i].gameObject);

            _Cards.Clear();
        }

        private void PickCard(Card card)
        {
            if (_FirstGuess.Active && _SecondGuess.Active)
            {
                print("Too soon, wait a moment");
                return;
            }

            if (!_FirstGuess.Active)
            {
                _FirstGuess.Set(card);
            }
            else if (!_SecondGuess.Active)
            {
                _SecondGuess.Set(card);

                print("1st G is: " + _FirstGuess.Card.Id + ",2nd G is: " + _SecondGuess.Card.Id);

                // Add to queue for compare guess
                CheckMatch(_FirstGuess, _SecondGuess);
            }
        }

        public void CheckMatch(MatchCardGuess firstGuess, MatchCardGuess secondGuess)
        {
            if (firstGuess.Equals(secondGuess))
            {
                Debug.Log("Correct Guess");
                // check combo
                if (Mathf.Abs(Time.time - _lastCorrectTime) < .5f)
                {
                    // COMBO...

                    _OnCombo?.Invoke();
                }

                // Destroy cards
                firstGuess.Clean();
                secondGuess.Clean();

                GameInfo.matchesCount++;
                _lastCorrectTime = Time.time;

                // check win condition
            }
            else
            {
                Debug.Log("Wrong Guess");
                _FirstGuess.Reset();
                _SecondGuess.Reset();
            }

            GameInfo.turnCount++;
            _OnMatchHappened?.Invoke();
        }

        ///////////////////////////////////////
        /// STATIC MEMEBERS
        ///////////////////////////////////////
        private static List<Card> _Cards = new();
        private static LevelConfig _Config;
        private MatchCardGuess _FirstGuess, _SecondGuess;

        private static Action _OnCombo = null;
        private static Action _OnMatchHappened = null;

        public static void StartGame()
        {
            GameInfo.Reset();

            Instance.gameManager.OpenGamePanel();

            GameInfo.levelNumber = PlayerProfile.LevelIndex;

            _Config = Factory.GetLevel(GameInfo.levelNumber);
            GameInfo.timer = _Config.timeLimit;
            GameInfo.time = _Config.timeLimit;

            Instance.LoadLevel();
            Instance.gameManager.OpenGamePanel();
        }

        public static void Win()
        {
            PlayerProfile.LevelIndex++;

            Instance.Clean();
            Instance.gameManager.OpenWinPanel();
        }

        public static void Lose()
        {
            Instance.Clean();
            Instance.gameManager.OpenLosePanel();
        }

        public static void BackToMainMenu()
        {
            Instance.Clean();
            Instance.gameManager.OpenMainMenu();
        }


        // Singleton pattern
        private static CardMatchingGameHandler instance;
        public static CardMatchingGameHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<CardMatchingGameHandler>();
                    if (instance == null)
                    {
                        instance = new GameObject().AddComponent<CardMatchingGameHandler>();
                        instance.gameObject.name = instance.GetType().Name;
                    }
                }

                return instance;
            }
        }

    }
}