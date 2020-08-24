using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Tbp_projekt
{
    public class Povezivanje
    {
        public NpgsqlConnection connection;

        public void Povezi()
        {
            string ConnectionString = "Server=localhost;Port=5432;User Id=postgres;Password = marago747;Database =test; ";
            connection = new NpgsqlConnection(ConnectionString);
            connection.Open();

        }

        public void Odspoji()
        {
            connection.Close();
        }
    }
}
