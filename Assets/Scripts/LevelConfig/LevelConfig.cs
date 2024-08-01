using UnityEngine;

namespace FlipFlop
{
    [CreateAssetMenu(fileName = "New Level", menuName = "MatchingCard/Creaet New Level", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [Range(2, 24)]
        public int numCard = 2;

        [Tooltip("After this time(s), game will over.")]
        public int timeLimit = 10;

#if UNITY_EDITOR
        private void OnValidate()
        {
            CardNumverValidation();
        }

        private void CardNumverValidation()
        {
            if (numCard % 2 != 0)
                numCard++;
        }
#endif
    }
}