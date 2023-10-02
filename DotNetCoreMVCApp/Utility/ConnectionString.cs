namespace DotNetCoreMVCApp.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=.;Initial Catalog=DotNetCoreDB;Integrated Security=True";
        public static string CName
        {
            get => cName;
        }
    }
}
