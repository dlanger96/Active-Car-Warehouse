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
    public partial class Automobili : Form
    {
        Povezivanje baza = new Povezivanje();
        int odabir = 0;
        public Automobili()
        {
            InitializeComponent();
        }
        private void Osvjezi(NpgsqlConnection connection)
        {
            string dodano = @"SELECT * FROM svi_automobili()";
            string sql = " SELECT \"Automobil\".\"id\", \"Automobil\".\"VIN\", \"Automobil\".\"naziv\", \"Proizvodac\".\"naziv\"," +
                "\"Vrsta_Automobila\".\"naziv\", \"Automobil\".\"cijena\", \"Karakteristike\".\"model\", \"Karakteristike\".\"vrsta_motora\"," +
                " \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", \"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" FROM" +
                "\"Automobil\", \"Proizvodac\", \"Vrsta_Automobila\", \"Karakteristike\" WHERE \"Automobil\".\"fk_proizvodac\" = \"Proizvodac\".\"id\" AND " +
                "\"Automobil\".\"fk_vrsta_automobila\" = \"Vrsta_Automobila\".\"id\" AND \"Automobil\".\"fk_karakteristike\" = \"Karakteristike\". \"id\" ; ";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            dataAdapter.Fill(automobilDs);
            dgvAutomobili.DataSource = automobilDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID";
            dgvAutomobili.Columns[1].HeaderText = "VIN";
            dgvAutomobili.Columns[2].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[3].HeaderText = "Proizvođač automobila";
            dgvAutomobili.Columns[4].HeaderText = "Vrsta automobila";
            dgvAutomobili.Columns[5].HeaderText = "Cijena u $";
            dgvAutomobili.Columns[6].HeaderText = "Model";
            dgvAutomobili.Columns[7].HeaderText = "Gorivo";
            dgvAutomobili.Columns[8].HeaderText = "Snaga u KW";
            dgvAutomobili.Columns[9].HeaderText = "Boja";
            dgvAutomobili.Columns[10].HeaderText = "Obujam motora CCM";
            dgvAutomobili.Columns[11].HeaderText = "Duljina vozila u m";

        }

        private void Napuni(NpgsqlConnection connection)
        {
            baza.Povezi();
            string sql = "SELECT \"Proizvodac\".\"naziv\" FROM \"Proizvodac\" ";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            DataTable dt = new DataTable();
            dataAdapter.Fill(automobilDs);
            cmd.ExecuteNonQuery();
            baza.Odspoji();

            cbProizvodaci.DataSource = automobilDs.Tables[0];
            cbProizvodaci.DisplayMember = automobilDs.Tables[0].Columns[0].ToString();
        }
        private void NapuniVrste(NpgsqlConnection connection)
        {
            baza.Povezi();
            string sql = "SELECT \"Vrsta_Automobila\".\"naziv\" FROM \"Vrsta_Automobila\" ";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            DataTable dt = new DataTable();
            dataAdapter.Fill(automobilDs);
            cmd.ExecuteNonQuery();
            baza.Odspoji();

            cbVrstaAutomobila.DataSource = automobilDs.Tables[0];
            cbVrstaAutomobila.DisplayMember = automobilDs.Tables[0].Columns[0].ToString();
        }

        private void Automobili_Load(object sender, EventArgs e)
        {
            baza.Povezi();
            Osvjezi(baza.connection);
            baza.Odspoji();
        }

        private void dgvAutomobili_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            odabir = int.Parse(dgvAutomobili.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvAutomobili_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPretrazivanjeNaziv_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT \"Automobil\".\"id\",\"Automobil\".\"VIN\", \"Automobil\".\"naziv\", \"Proizvodac\".\"naziv\", \"Vrsta_Automobila\".\"naziv\", \"Automobil\".\"cijena\",\"Karakteristike\".\"model\"" +
                ", \"Karakteristike\".\"vrsta_motora\", \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", \"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" " +
                "FROM \"Automobil\",\"Proizvodac\",\"Vrsta_Automobila\",\"Karakteristike\" WHERE \"Automobil\".\"fk_proizvodac\"=\"Proizvodac\".\"id\" AND \"Automobil\".\"fk_vrsta_automobila\" = " +
                "\"Vrsta_Automobila\".\"id\" AND \"Automobil\".\"fk_karakteristike\" = \"Karakteristike\".\"id\" AND \"Automobil\".\"naziv\" LIKE '%"+ txtPretrazivanjeNaziv.Text + "%' ORDER BY 1 ;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobiliDs = new DataSet();
            dataAdapter.Fill(automobiliDs);
            dgvAutomobili.DataSource = automobiliDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID";
            dgvAutomobili.Columns[1].HeaderText = "VIN";
            dgvAutomobili.Columns[2].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[3].HeaderText = "Proizvođač automobila";
            dgvAutomobili.Columns[4].HeaderText = "Vrsta automobila";
            dgvAutomobili.Columns[5].HeaderText = "Cijena u $";
            dgvAutomobili.Columns[6].HeaderText = "Model";
            dgvAutomobili.Columns[7].HeaderText = "Gorivo";
            dgvAutomobili.Columns[8].HeaderText = "Snaga u KW";
            dgvAutomobili.Columns[9].HeaderText = "Boja";
            dgvAutomobili.Columns[10].HeaderText = "Obujam motora CCM";
            dgvAutomobili.Columns[11].HeaderText = "Duljina vozila u m";
        }

        private void cbProizvodaci_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT \"Automobil\".\"id\",\"Automobil\".\"VIN\", \"Automobil\".\"naziv\", \"Proizvodac\".\"naziv\", \"Vrsta_Automobila\".\"naziv\", \"Automobil\".\"cijena\",\"Karakteristike\".\"model\"" +
                ", \"Karakteristike\".\"vrsta_motora\", \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", \"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" " +
                "FROM \"Automobil\",\"Proizvodac\",\"Vrsta_Automobila\",\"Karakteristike\" WHERE \"Automobil\".\"fk_proizvodac\"=\"Proizvodac\".\"id\" AND \"Automobil\".\"fk_vrsta_automobila\" = " +
                "\"Vrsta_Automobila\".\"id\" AND \"Automobil\".\"fk_karakteristike\" = \"Karakteristike\".\"id\" AND \"Proizvodac\".\"naziv\" LIKE '" + cbProizvodaci.Text + "' ORDER BY 1 ;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobiliDs = new DataSet();
            dataAdapter.Fill(automobiliDs);
            dgvAutomobili.DataSource = automobiliDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID";
            dgvAutomobili.Columns[1].HeaderText = "VIN";
            dgvAutomobili.Columns[2].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[3].HeaderText = "Proizvođač automobila";
            dgvAutomobili.Columns[4].HeaderText = "Vrsta automobila";
            dgvAutomobili.Columns[5].HeaderText = "Cijena u $";
            dgvAutomobili.Columns[6].HeaderText = "Model";
            dgvAutomobili.Columns[7].HeaderText = "Gorivo";
            dgvAutomobili.Columns[8].HeaderText = "Snaga u KW";
            dgvAutomobili.Columns[9].HeaderText = "Boja";
            dgvAutomobili.Columns[10].HeaderText = "Obujam motora CCM";
            dgvAutomobili.Columns[11].HeaderText = "Duljina vozila u m";

        }

        private void cbProizvodaci_MouseClick(object sender, MouseEventArgs e)
        {
            baza.Povezi();
            Osvjezi(baza.connection);
            Napuni(baza.connection);
            baza.Odspoji();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbProizvodaci.ResetText();
            cbVrstaAutomobila.ResetText();
            baza.Povezi();
            Osvjezi(baza.connection);
            baza.Odspoji();
        }

        private void cbVrstaAutomobila_MouseClick(object sender, MouseEventArgs e)
        {
            baza.Povezi();
            Osvjezi(baza.connection);
            NapuniVrste(baza.connection);
            baza.Odspoji();
        }

        private void cbVrstaAutomobila_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void cbProizvodaci_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void cbVrstaAutomobila_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT \"Automobil\".\"id\",\"Automobil\".\"VIN\", \"Automobil\".\"naziv\", \"Proizvodac\".\"naziv\", \"Vrsta_Automobila\".\"naziv\", \"Automobil\".\"cijena\",\"Karakteristike\".\"model\"" +
                ", \"Karakteristike\".\"vrsta_motora\", \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", \"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" " +
                "FROM \"Automobil\",\"Proizvodac\",\"Vrsta_Automobila\",\"Karakteristike\" WHERE \"Automobil\".\"fk_proizvodac\"=\"Proizvodac\".\"id\" AND \"Automobil\".\"fk_vrsta_automobila\" = " +
                "\"Vrsta_Automobila\".\"id\" AND \"Automobil\".\"fk_karakteristike\" = \"Karakteristike\".\"id\" AND \"Vrsta_Automobila\".\"naziv\" LIKE '" + cbVrstaAutomobila.Text + "' ORDER BY 1 ;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobiliDs = new DataSet();
            dataAdapter.Fill(automobiliDs);
            dgvAutomobili.DataSource = automobiliDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID";
            dgvAutomobili.Columns[1].HeaderText = "VIN";
            dgvAutomobili.Columns[2].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[3].HeaderText = "Proizvođač automobila";
            dgvAutomobili.Columns[4].HeaderText = "Vrsta automobila";
            dgvAutomobili.Columns[5].HeaderText = "Cijena u $";
            dgvAutomobili.Columns[6].HeaderText = "Model";
            dgvAutomobili.Columns[7].HeaderText = "Gorivo";
            dgvAutomobili.Columns[8].HeaderText = "Snaga u KW";
            dgvAutomobili.Columns[9].HeaderText = "Boja";
            dgvAutomobili.Columns[10].HeaderText = "Obujam motora CCM";
            dgvAutomobili.Columns[11].HeaderText = "Duljina vozila u m";
        }
    }
}
