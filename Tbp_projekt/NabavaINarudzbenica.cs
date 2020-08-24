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
    public partial class NabavaINarudzbenica : Form
    {
        Povezivanje baza = new Povezivanje();
        int zapKol = 0;
        int odabraniId = 0;
        int pozicija = 0;
        string stanje_na_datum = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string datum_zaprimanja = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


        public NabavaINarudzbenica()
        {
            InitializeComponent();
        }

        private void Nabava_Prikaz(NpgsqlConnection connection)
        {
            


            string sql = "SELECT \"Automobil\".\"naziv\",\"Nabava_Automobila\".\"stanje\",\"Nabava_Automobila\".\"stanje_na_datum\",\"Nabava_Automobila\".\"kolicina_za_narucivanje\",\"Nabava_Automobila\"" +
                ".\"datum_zaprimanja\" FROM \"Automobil\", \"Nabava_Automobila\" WHERE \"Nabava_Automobila\".\"fk_automobil\" = \"Automobil\".\"id\";";

         

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
           
            dataAdapter.Fill(automobilDs);
          
            dgvNabavaAutomobila.DataSource = automobilDs.Tables[0];
            dgvNabavaAutomobila.Columns[0].HeaderText = "Naziv Automobila";
            dgvNabavaAutomobila.Columns[1].HeaderText = "Stanje u skladištu";
            dgvNabavaAutomobila.Columns[2].HeaderText = "Stanje na datum";
            dgvNabavaAutomobila.Columns[3].HeaderText = "Količina koja se naručuje";
            dgvNabavaAutomobila.Columns[4].HeaderText = "Datum kada je automobil zaprimljen";
        }

        private void Narudzbenica_Prikaz(NpgsqlConnection connection)
        {
           

            string sql = "SELECT \"Narudzbenica\".\"id\",\"Automobil\".\"naziv\", \"Narudzbenica\".\"datum\", \"Narudzbenica\".\"zaprimljeno\", \"Narudzbenica\".\"kolicina\", \"Narudzbenica\".\"fk_nabava_automobila\"," +
                "\"Narudzbenica\".\"fk_automobil\" FROM \"Automobil\", \"Narudzbenica\", \"Nabava_Automobila\" WHERE \"Narudzbenica\".\"fk_nabava_automobila\" = \"Nabava_Automobila\".\"id\" AND " +
                "\"Narudzbenica\".\"fk_automobil\" = \"Automobil\".\"id\";";



            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();

            dataAdapter.Fill(automobilDs);

            dgvNarudzbenica.DataSource = automobilDs.Tables[0];
            dgvNarudzbenica.Columns[0].HeaderText = "Jedinstveni broj narudžbenice";
            dgvNarudzbenica.Columns[1].HeaderText = "Naziv automobila";
            dgvNarudzbenica.Columns[2].HeaderText = "Datum zaprimanja narudžbe";
            dgvNarudzbenica.Columns[3].HeaderText = "Količina koju je korisnik zaprimio";
            dgvNarudzbenica.Columns[4].HeaderText = "Količina koja je naručena";
            dgvNarudzbenica.Columns[5].HeaderText = "Jedinstven broj nabave automobila";
            dgvNarudzbenica.Columns[6].HeaderText = "Jedinstven broj automobila";
        }

        private void NabavaINarudzbenica_Load(object sender, EventArgs e)
        {
            baza.Povezi();
            Nabava_Prikaz(baza.connection);
            Narudzbenica_Prikaz(baza.connection);
            baza.Odspoji();
        }

        private void btnUnesiZapKol_Click(object sender, EventArgs e)
        {
            zapKol = int.Parse(txtZaprimljenaKol.Text.ToString());
            pozicija = int.Parse(dgvNarudzbenica.CurrentRow.Cells[0].Value.ToString());
            baza.Povezi();

            if (zapKol >0)
            {
                string sql = "UPDATE \"Narudzbenica\" SET \"datum\" = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', \"zaprimljeno\" = " + zapKol + " WHERE \"Narudzbenica\".\"id\" = " + pozicija + ";  ";

                NpgsqlCommand command = new NpgsqlCommand(sql, baza.connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                
            }
            else
            {
                MessageBox.Show("Molim Vas unesite kolicinu koja neće biti manja od 0 ili imati negativne vrijednosti","UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
            Nabava_Prikaz(baza.connection);
            Narudzbenica_Prikaz(baza.connection);
            baza.Odspoji();
        }

        private void dgvNarudzbenica_SelectionChanged(object sender, EventArgs e)
        {
            txtPoz.Text = dgvNarudzbenica.CurrentRow.Cells[0].Value.ToString();
             
        }

        private void dtpStanjeNaDatum_ValueChanged(object sender, EventArgs e)
        {

            stanje_na_datum = dtpStanjeNaDatum.Value.ToString("yyyy-MM-dd HH:mm:ss");
            datum_zaprimanja = dtpDatumZaprimanja.Value.ToString("yyyy-MM-dd HH:mm:ss");


            string sql = "SELECT \"Automobil\".\"naziv\",\"Nabava_Automobila\".\"stanje\",\"Nabava_Automobila\".\"stanje_na_datum\",\"Nabava_Automobila\".\"kolicina_za_narucivanje\",\"Nabava_Automobila\"" +
                ".\"datum_zaprimanja\" FROM \"Automobil\", \"Nabava_Automobila\" WHERE \"Nabava_Automobila\".\"fk_automobil\" = \"Automobil\".\"id\" AND \"Nabava_Automobila\".\"stanje_na_datum\">= " +
                "'" + stanje_na_datum + "'  AND \"Nabava_Automobila\".\"datum_zaprimanja\"<='" + datum_zaprimanja + "';";



            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobilDs = new DataSet();

            dataAdapter.Fill(automobilDs);

            dgvNabavaAutomobila.DataSource = automobilDs.Tables[0];
        }

        private void dtpDatumZaprimanja_ValueChanged(object sender, EventArgs e)
        {
            stanje_na_datum = dtpStanjeNaDatum.Value.ToString("yyyy-MM-dd HH:mm:ss");
            datum_zaprimanja = dtpDatumZaprimanja.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sql = "SELECT \"Automobil\".\"naziv\",\"Nabava_Automobila\".\"stanje\",\"Nabava_Automobila\".\"stanje_na_datum\",\"Nabava_Automobila\".\"kolicina_za_narucivanje\",\"Nabava_Automobila\"" +
                ".\"datum_zaprimanja\" FROM \"Automobil\", \"Nabava_Automobila\" WHERE \"Nabava_Automobila\".\"fk_automobil\" = \"Automobil\".\"id\" AND \"Nabava_Automobila\".\"stanje_na_datum\">= " +
                "'" + stanje_na_datum + "'  AND \"Nabava_Automobila\".\"datum_zaprimanja\"<='" + datum_zaprimanja + "';";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobilDs = new DataSet();
            dataAdapter.Fill(automobilDs);
            dgvNabavaAutomobila.DataSource = automobilDs.Tables[0];
        }
    }
}
