namespace Library.Configurations
{
    internal static class ConnectionString
    {
        internal static String MsSqlConnectionString =>
            @"Data Source=.\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False";
    }
}
