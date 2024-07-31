
using UnityEngine;

namespace FlipFlop
{

    [CreateAssetMenu(fileName = "Level", menuName = "MatchingCard/Level", order = 0)]
    public class Level : ScriptableObject
    {
        public string m_name;
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