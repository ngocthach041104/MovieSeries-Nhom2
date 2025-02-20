namespace MovieSeries.CommonLayer.Utilities
{
    public static class Validator
    {
        // Kiểm tra email có hợp lệ không: đơn giản chỉ là kiểm tra có chứa "@" và "."
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }
    }
}﻿
