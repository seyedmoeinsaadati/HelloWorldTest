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


        private void Awake()
        {
            _cardPrefab.gameObject.SetActive(false);
        }

        private void LoadLevel()
        {
#if UNITY_EDITOR
            Debug.Log($"Level: {GameInfo.levelNumber}");
            Debug.Log($"Card Counts: {Config.numCard}");
            Debug.Log($"Level Time: {Config.timeLimit}");
#endif

            // spawn cards
            Cards.Clear();

            int spriteCount = Config.numCard / 2;

            Sprite[] cardSprites = Factory.Sprites.GetSprites(spriteCount);
            for (int id = 0, index = 0; id < spriteCount; id++)
            {
                var card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(index, id, cardSprites[id])
                        .SetOnClick(PickCard);

                    Cards.Add(card);
                    index++;
                }

                card = Instantiate(Instance._cardPrefab, Instance._cardContainer);

                if (card != null)
                {
                    card.Setup(index, id, cardSprites[id])
                        .SetOnClick(PickCard);

                    Cards.Add(card);
                    index++;
                }
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

        private void PickCard(Card card)
        {
            if (firstGuess.Active && secondGuess.Active)
            {
                print("Too soon, wait a moment");
                return;
            }

            if (!firstGuess.Active)
            {
                firstGuess.Set(card);
            }
            else if (!secondGuess.Active)
            {
                secondGuess.Set(card);

                print("1st G is: " + firstGuess.Card.Id + ",2nd G is: " + secondGuess.Card.Id);

                // Add to queue for compare guess
            }
        }

        public void CheckMatch(MatchCardGuess firstGuess, MatchCardGuess secondGuess)
        {
            GameInfo.turnCount++;

            if (firstGuess.Equals(secondGuess))
            {
                print("Correct Guess");
                // Destroy cards
                GameInfo.matchesCount++;
            }
            else
            {
                firstGuess.Reset();
                secondGuess.Reset();
            }
        }

        ///////////////////////////////////////
        /// STATIC MEMEBERS
        ///////////////////////////////////////
        private static List<Card> Cards = new();
        private static LevelConfig Config;

        public MatchCardGuess firstGuess, secondGuess;


        public static void StartGame()
        {
            GameInfo.Reset();

            Instance.gameManager.OpenGamePanel();

            GameInfo.levelNumber = PlayerProfile.LevelIndex;

            Config = Factory.GetLevel(GameInfo.levelNumber);
            GameInfo.timer = Config.timeLimit;
            GameInfo.time = Config.timeLimit;

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