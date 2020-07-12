using System;
using System.Data;
using System.Data.SqlClient;
using FaustinoStore.Shared;

namespace FaustinoStore.Infra.DataContexts
{
  public class FaustinoDataContext : IDisposable
  {
    public SqlConnection Connection { get; set; }

    public FaustinoDataContext()
    {
      Connection = new SqlConnection(Settings.ConnectionString);
      Connection.Open();
    }

    public void Dispose()
    {
      if (Connection.State != ConnectionState.Closed)
        Connection.Close();
    }
  }
}