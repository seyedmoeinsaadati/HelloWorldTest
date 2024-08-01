using System;
using UnityEngine.SocialPlatforms.Impl;

namespace FlipFlop
{
    public static class GameInfo
    {
        public static Action onStart = null;
        public static Action onWin = null;
        public static Action onLose = null;

        public static int levelNumber;
        public static bool winner = false;
        public static bool playing = false;

        public static float timer;
        public static float time = 0;
        public static float cardCount = 0;
        public static int matchesCount;
        public static int turnCount;
        public static int comboCount;

        public static int CalculateScore()
        {
            // write score formula here...
            return (int)timer * 10 + comboCount;
        }


        public static void Reset()
        {
            playing = winner = false;

            levelNumber = -1;
            time = timer = 0;
            matchesCount = turnCount = comboCount = 0;
        }
    }
}