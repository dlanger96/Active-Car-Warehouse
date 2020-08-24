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
    public partial class StatistikaProizvodaci : Form
    {
        Povezivanje pov = new Povezivanje();

        public StatistikaProizvodaci()
        {
            InitializeComponent();
        }

        private void StatistikaMenu_Load(object sender, EventArgs e)
        {
            pov.Povezi();
            Prikaz(pov.connection);
            pov.Odspoji();

        }

        private void Prikaz(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Proizvodac\".\"naziv\", COUNT (*) AS automobili_po_proizvodacu FROM \"Proizvodac\",\"Automobil\" WHERE \"Proizvodac\".\"id\" = \"Automobil\".\"fk_proizvodac\" " +
                "GROUP BY 1 ORDER BY 2 DESC;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet statistikaDs = new DataSet();
            dataAdapter.Fill(statistikaDs);
            chartProizvodaci.DataSource = statistikaDs.Tables[0];
            chartProizvodaci.Series[0].XValueMember = "Naziv";
            chartProizvodaci.Series[0].YValueMembers = "automobili_po_proizvodacu";
            chartProizvodaci.DataBind();
            dgvStatistikaProizvodac.DataSource = statistikaDs.Tables[0];
        }
    }
}
