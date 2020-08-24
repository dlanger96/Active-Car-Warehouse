using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Tbp_projekt
{
    public partial class StatistikaNarucivanja : Form
    {
        Povezivanje pov = new Povezivanje();

        public StatistikaNarucivanja()
        {
            InitializeComponent();
        }

        private void StatistikaNarucivanja_Load(object sender, EventArgs e)
        {
            pov.Povezi();
            Prikaz(pov.connection);
            pov.Odspoji();
        }

        private void Prikaz(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Automobil\".\"naziv\", COUNT(*) as broj_narudzbi FROM \"Narudzbenica\", \"Automobil\" WHERE \"Narudzbenica\".\"fk_automobil\" = \"Automobil\".\"id\"" +
                "GROUP BY 1 ;";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet statistikaDs = new DataSet();
            dataAdapter.Fill(statistikaDs);
            chartNarucivanje.DataSource = statistikaDs.Tables[0];
            chartNarucivanje.Series[0].XValueMember = "Naziv";
            chartNarucivanje.Series[0].YValueMembers = "broj_narudzbi";
            chartNarucivanje.DataBind();
            dgvNarucivanje.DataSource = statistikaDs.Tables[0];
        }


    }
}
