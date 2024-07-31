using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace FlipFlop
{
    public class CardMatchingGameHandler : MonoBehaviour
    {
        [Space]
        [SerializeField] private GameStateManager gameManager;
        [SerializeField] private Transform _cardContainer;
        [SerializeField] private Card _cardPrefab;

        private void Awake()
        {
            _cardPrefab.gameObject.SetActive(false);
        }

        private static void LoadLevel()
        {
#if UNITY_EDITOR
            Debug.Log($"Level: {GameInfo.levelNumber}");
            Debug.Log($"Card Counts: {Config.numCard}");
            Debug.Log($"Level Time: {Config.timeLimit}");
#endif

            // spawn cards
            Cards.Clear();
            Sprite[] cardSprites = Factory.Sprites.GetSprites(Config.numCard / 2);
            for (int spriteIndex = 0, cardId = 0; spriteIndex < Config.numCard / 2; spriteIndex++)
            {
                var card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(cardId, cardSprites[spriteIndex]);
                    Cards.Add(card);
                }

                card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(cardId, cardSprites[spriteIndex]);
                    Cards.Add(card);
                }

                cardId++;
            }

            // shuffle cards
            foreach (var card in Cards)
            {
                card.transform.SetSiblingIndex(UnityEngine.Random.Range(0, Cards.Count));
            }
        }

        private void Clean()
        {
            for (int i = 0; i < Cards.Count; i++)
                Destroy(Cards[i].gameObject);

            Cards.Clear();
        }

        ///////////////////////////////////////
        /// STATIC MEMEBERS
        ///////////////////////////////////////
        private static List<Card> Cards = new();
        private static LevelConfig Config;

        public static void StartGame()
        {
            GameInfo.Reset();

            Instance.gameManager.OpenGamePanel();

            GameInfo.levelNumber = PlayerProfile.LevelIndex;

            Config = Factory.GetLevel(GameInfo.levelNumber);

            GameInfo.timer = Config.timeLimit;
            GameInfo.time = Config.timeLimit;

            LoadLevel();
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