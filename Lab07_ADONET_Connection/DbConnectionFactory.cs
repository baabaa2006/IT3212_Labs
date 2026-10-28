using System.Configuration;
using System.Data.SqlClient;

namespace Lab07_ADONET_Connection
{
    public static class DbConnectionFactory
    {
        private const string ConnectionName = "QLSinhVienDb";

        // Đọc chuỗi kết nối từ App.config theo tên
        private static string GetConnectionString()
        {
            ConnectionStringSettings cs =
                ConfigurationManager.ConnectionStrings[ConnectionName];

            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                throw new ConfigurationErrorsException(
                    "Không tìm thấy chuỗi kết nối '" + ConnectionName + "' trong App.config.");

            return cs.ConnectionString;
        }

        public static SqlConnection Create()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}