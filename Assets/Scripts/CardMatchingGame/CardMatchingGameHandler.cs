using System.Collections.Generic;
using UnityEngine;

namespace FlipFlop
{
    public class CardMatchingGameHandler : MonoBehaviour
    {
        [Space]
        [SerializeField] private GameStateManager gameManager;
        [SerializeField] private Transform _cardContainer;
        [SerializeField] private Card _cardPrefab;

        ///////////////////////////////////////
        /// STATIC MEMEBERS
        ///////////////////////////////////////
        private static List<Card> Cards = new();

        public static void StartGame()
        {
            GameInfo.Reset();

            Instance.gameManager.OpenGamePanel();

            GameInfo.levelNumber = PlayerProfile.LevelIndex;

            LoadLevel();
            Instance.gameManager.OpenGamePanel();
        }
        public static void Win()
        {
            Clean();
            PlayerProfile.LevelIndex++;
            Instance.gameManager.OpenWinPanel();
        }

        public static void Lose()
        {
            Instance.gameManager.OpenLosePanel();
        }

        public static void BackToMainMenu()
        {
            Instance.gameManager.OpenMainMenu();
        }


        public static void LoadLevel()
        {
            var config = Factory.GetLevel(GameInfo.levelNumber);
            GameInfo.time = config.timeLimit;

            // spawn cards
            Cards.Clear();
            Sprite[] cardSprites = Factory.Sprites.GetSprites(config.numCard);
            for (int i = 0; i < cardSprites.Length; i++)
            {
                var card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(i, cardSprites[i]);
                    Cards.Add(card);
                }
            }
        }

        /// </summary>
        /// Clean the playground after finishing level
        /// </summary>
        public static void Clean()
        {
            for (int i = Cards.Count - 1; i >= 0; i--)
                Destroy(Cards[i]);

            Cards.Clear();
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