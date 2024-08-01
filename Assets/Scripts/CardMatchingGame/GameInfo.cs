using System;
using Unity.VisualScripting;

namespace FlipFlop
{
    public static class GameInfo
    {
        public static Action onStart = null;
        public static Action onWin = null;
        public static Action onLose = null;

        public static int levelNumber;
        public static bool winner = false;

        public static float timer;
        public static float time = 0;
        public static int matchesCount;
        public static int turnCount;

        public static void Reset()
        {
            winner = false;

            levelNumber = -1;
            time = timer = 0;
            matchesCount = turnCount = 0;
        }
    }
}