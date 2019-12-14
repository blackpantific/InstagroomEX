using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Contracts
{
    public interface ISQLiteConnectionService
    {
        string GetDatabasePath(string filename);
        SQLiteAsyncConnection GetConnection();
    }
}
