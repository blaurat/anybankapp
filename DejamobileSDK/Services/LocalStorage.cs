using SQLite;
using System;

namespace DejamobileSDK.Services
{
    internal class LocalStorage
    {
        public SQLiteConnection Connection { get; private set; }

        public void Connect(string databasePath)
        {
            try
            {
                Connection = new SQLiteConnection(databasePath);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                Connection = null;
            }
        }

        public void Disconnect()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
