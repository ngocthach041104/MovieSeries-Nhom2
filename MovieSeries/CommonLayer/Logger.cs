using System;

namespace MovieSeries.CommonLayer.Utilities
{
    public static class Logger
    {
        // Ghi log đơn giản ra console với thời gian hiện tại
        public static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}﻿
