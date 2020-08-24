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
    public partial class StatistikaGorivo : Form
    {
        Povezivanje pov = new Povezivanje();

        public StatistikaGorivo()
        {
            InitializeComponent();
        }

        private void StatistikaGorivo_Load(object sender, EventArgs e)
        {
            pov.Povezi();
            Prikaz(pov.connection);
            pov.Odspoji();
        }

        private void Prikaz(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Karakteristike\".\"vrsta_motora\", COUNT (*) AS Tip_motora FROM \"Karakteristike\" GROUP BY 1;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet statistikaDs = new DataSet();

            dataAdapter.Fill(statistikaDs);
            chartGorivo.DataSource = statistikaDs.Tables[0];
            chartGorivo.Series[0].XValueMember = "vrsta_motora";
            chartGorivo.Series[0].YValueMembers = "Tip_motora";
            chartGorivo.DataBind();

            dgvGorivo.DataSource = statistikaDs.Tables[0];
        }
    }
}
