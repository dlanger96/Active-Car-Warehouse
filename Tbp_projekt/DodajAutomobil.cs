using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Tbp_projekt
{
    public partial class DodajAutomobil : Form
    {
        Povezivanje pov = new Povezivanje();
        int pozProizvodac = 0;
        int pozKarakteristike = 0;
        int pozVrstaAutomobila = 0;
        public DodajAutomobil()
        {
            InitializeComponent();
        }

        private void DodajAutomobil_Load(object sender, EventArgs e)
        {
            pov.Povezi();
            OsvjeziKarakteristike(pov.connection);
            OsvjeziProizvodace(pov.connection);
            OsvjeziVrsteAutomobila(pov.connection);
            pov.Odspoji();

        }

        private void OsvjeziKarakteristike(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Karakteristike\".\"id\", \"Karakteristike\".\"model\", \"Karakteristike\".\"vrsta_motora\", \"Karakteristike\".\"snaga\", \"Karakteristike\".\"boja\", " +
                "\"Karakteristike\".\"obujam_motora\", \"Karakteristike\".\"duljina_vozila\" FROM \"Karakteristike\" ORDER BY 1 ASC ;";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            dataAdapter.Fill(automobilDs);
            dgvKarakteristikeew1.DataSource = automobilDs.Tables[0];
        }

        private void OsvjeziProizvodace(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Proizvodac\".\"id\",\"Proizvodac\".\"naziv\", \"Proizvodac\".\"opis\" FROM \"Proizvodac\" ORDER BY 1 ASC; ";

           
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            dataAdapter.Fill(automobilDs);
            dgvProizvodac.DataSource = automobilDs.Tables[0];
        }

        private void OsvjeziVrsteAutomobila(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Vrsta_Automobila\".\"id\", \"Vrsta_Automobila\".\"naziv\", \"Vrsta_Automobila\".\"opis\" FROM \"Vrsta_Automobila\" ORDER BY 1; ";

      

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            dataAdapter.Fill(automobilDs);
            dgvVrstaAutomobila.DataSource = automobilDs.Tables[0];
        }

        private void dgvKarakteristikeew1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pozKarakteristike = int.Parse(dgvKarakteristikeew1.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                pozKarakteristike = 0;
            }

            txtKarakteristikeId.Text = pozKarakteristike.ToString();
        }

        private void dgvProizvodac_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pozProizvodac = int.Parse(dgvProizvodac.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pozProizvodac = 0;
            }

            txtProizvodacId.Text = pozProizvodac.ToString();

        }

        private void dgvVrstaAutomobila_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pozVrstaAutomobila = int.Parse(dgvVrstaAutomobila.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pozVrstaAutomobila = 0;
            }

            txtVrsteAutomobilaId.Text = pozVrstaAutomobila.ToString();
        }

        private void btnDodajAuto_Click(object sender, EventArgs e)
        {
          
            string koji = txtIdAutomobila.Text.ToString();
            txtIdAutomobila.Text = txtCijena.ToString();
            


            
            
            
                if (txtVIN.Text == "")
                {
                    MessageBox.Show("Molim Vas unesite VIN za automobil", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    pov.Povezi();
                    string sql = "INSERT INTO \"Automobil\" VALUES (DEFAULT ,'" + txtVIN.Text.ToString() + "' ,'" + txtNazivAutomobila.Text.ToString() + "', '" + dtpGodina.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', " + int.Parse(txtMinKol.Text.ToString()) + "," +
                        "" + int.Parse(txtKolNarucivanja.Text.ToString()) + ", CAST('" + txtCijena.Text.ToString() + "' AS money), " + int.Parse(txtVrsteAutomobilaId.Text.ToString()) + ", " + int.Parse(txtProizvodacId.Text.ToString()) + ", " + int.Parse(txtKarakteristikeId.Text.ToString()) + "); ";
                    NpgsqlCommand command = new NpgsqlCommand(sql, pov.connection);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                pov.Odspoji();
            
           
        }
    }
}
