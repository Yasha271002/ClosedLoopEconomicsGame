﻿using System.Diagnostics;

namespace ClosedLoopEconomicsGame.Helpers
{
    public static class DebugHelper
    {
        public static bool IsRunningInDebugMode { get; private set; }

        static DebugHelper()
        {
            Initialize();
        }

        [Conditional("DEBUG")]
        private static void Initialize()
        {
            IsRunningInDebugMode = true;
        }
    }
}
