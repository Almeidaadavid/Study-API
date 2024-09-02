using System.Text;

namespace API.Data.Connection {
    public static class ConnectionStringBuilder {

        public static string BuildConnectionString() {
            // Ainda não está funcionando
            //StringBuilder sb = new StringBuilder();
            string? server = Environment.GetEnvironmentVariable("DB_SERVER");
            string? port = Environment.GetEnvironmentVariable("DB_PORT");
            string? database = Environment.GetEnvironmentVariable("DB_NAME");
            string? user = Environment.GetEnvironmentVariable("DB_USER");
            string? password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            return $"Host={server};Port={port};Database={database};Username={user};Password={password}"; ;
        }

    }
}
