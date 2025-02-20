using System;

namespace MovieSeries.CommonLayer.Utilities
{
    public static class ErrorHandler
    {
        // Trả về thông báo lỗi đơn giản từ exception (có thể tích hợp logging, custom message, v.v.)
        public static string GetErrorMessage(Exception ex)
        {
            // Ở đây bạn có thể thực hiện log lỗi hoặc xử lý phức tạp hơn nếu cần
            return ex.Message;
        }
    }
}
