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
    public partial class PrikazSkladista : Form
    {
        Povezivanje baza = new Povezivanje();
        int kljuc = 0;
        int kolicina = 0;
        string poz = "";
        int pozicija = 0;
        string datumpocetak = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string datumkraj = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public PrikazSkladista()
        {
            InitializeComponent();
        }

        private void Osvjezi(NpgsqlConnection connection)
        {
            string sql = "SELECT \"Automobil\".\"id\",\"Automobil\".\"naziv\",\"Stanje_Na_Skladistu\".\"kolicina\",\"Automobil\".\"min_kolicina\",\"Stanje_Na_Skladistu\".\"poziciju_u_skladistu\"" +
                " FROM \"Stanje_Na_Skladistu\",\"Automobil\" WHERE \"Stanje_Na_Skladistu\".\"fk_automobil\" = \"Automobil\".\"id\" ORDER BY 1 ";

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();

            dataAdapter.Fill(automobilDs);
            dgvAutomobili.DataSource = automobilDs.Tables[0];
            dgvAutomobili.Columns[0].HeaderText = "ID automobila";
            dgvAutomobili.Columns[1].HeaderText = "Naziv automobila";
            dgvAutomobili.Columns[2].HeaderText = "Količina raspoloživa na skladištu";
            dgvAutomobili.Columns[3].HeaderText = "Minimalna količina na skladištu";
            dgvAutomobili.Columns[4].HeaderText = "Pozicija na parkingu";
            this.dgvAutomobili.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvAutomobili.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvAutomobili.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvAutomobili.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvAutomobili.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void PrikazSkladista_Load(object sender, EventArgs e)
        {
            baza.Povezi();
            Osvjezi(baza.connection);
            Osvjezi_Evidenciju(baza.connection);
            baza.Odspoji();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {           
                 kljuc = int.Parse(txtFkAutomobil.Text.ToString());
                 kolicina = int.Parse(txtKolicina.Text.ToString());
                 poz = txtPozicijaSk.Text.ToString();

                if (kolicina > 0 && kljuc != 0)
                {
                    baza.Povezi();
                    string sql = "INSERT INTO \"Stanje_Na_Skladistu\" VALUES (" + kljuc + "," + kolicina + ", '" + poz + "');";
                    NpgsqlCommand command = new NpgsqlCommand(sql, baza.connection);
                    command.ExecuteNonQuery();
                    Osvjezi(baza.connection);
                    Osvjezi_Evidenciju(baza.connection);
                    baza.Odspoji();
                    
                }
            else
            {
                MessageBox.Show("Količina automobila na skladištu ne može biti negativna ili biti 0", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAutomobili_SelectionChanged(object sender, EventArgs e)
        {
            
            try
            {
                pozicija = int.Parse(dgvAutomobili.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                
                pozicija = 0;
            }

            txtFkAutomobil.Text = pozicija.ToString();
        }
        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            kljuc = int.Parse(txtFkAutomobil.Text.ToString());
            kolicina = int.Parse(txtKolicina.Text.ToString());
            poz = txtPozicijaSk.Text.ToString();

            if (pozicija !=0)
            {
                if (kolicina >=0 )
                {
                    if (poz == "")
                    {
                        MessageBox.Show("Molim Vas unesite parking na kojemu se nalazi automobil", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                    else
                    {
                        baza.Povezi();
                        string sql = "UPDATE \"Stanje_Na_Skladistu\" SET \"kolicina\" = " + kolicina + ", \"poziciju_u_skladistu\" = '" + poz + "' WHERE \"fk_automobil\" = " + kljuc + ";";
                        NpgsqlCommand command = new NpgsqlCommand(sql, baza.connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Osvjezi(baza.connection);
                        Osvjezi_Evidenciju(baza.connection);
                        baza.Odspoji();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Molim Vas unesite količinu automobila koja neće biti 0 ili imati negativnu vrijednost", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Molim Vas odaberite automobil koji želite ažurirati", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Osvjezi_Evidenciju(NpgsqlConnection connection)
        {

            string sql = "SELECT \"Evidencija_Skladista\".\"evidencija_datum\", \"Evidencija_Skladista\".\"prijasnja_kolicina\", \"Evidencija_Skladista\".\"nova_kolicina\", \"Evidencija_Skladista\".\"tip_posla\","+"" +
                "\"Automobil\".\"naziv\" FROM \"Evidencija_Skladista\",\"Automobil\" WHERE \"Evidencija_Skladista\".\"fk_automobil\" = \"Automobil\".\"id\";";


            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, connection);
            DataSet automobilDs = new DataSet();
            
            dataAdapter.Fill(automobilDs);
           
            dgvEvidencija.DataSource = automobilDs.Tables[0];
            dgvEvidencija.Columns[0].HeaderText = "Datum unosa";
            dgvEvidencija.Columns[1].HeaderText = "Prijašnja količina";
            dgvEvidencija.Columns[2].HeaderText = "Nova količina na skladištu";
            dgvEvidencija.Columns[3].HeaderText = "Tip posla";
            dgvEvidencija.Columns[4].HeaderText = "Naziv automobila";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpPocetak_ValueChanged(object sender, EventArgs e)
        {
            datumpocetak = dtpPocetak.Value.ToString("yyyy-MM-dd HH:mm:ss");
            datumkraj = dtpKraj.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sql =
                "SELECT \"Evidencija_Skladista\".\"evidencija_datum\", \"Evidencija_Skladista\".\"prijasnja_kolicina\", \"Evidencija_Skladista\".\"nova_kolicina\", \"Evidencija_Skladista\".\"tip_posla\"," + "" +
                "\"Automobil\".\"naziv\" FROM \"Evidencija_Skladista\",\"Automobil\" WHERE \"Evidencija_Skladista\".\"fk_automobil\" = \"Automobil\".\"id\" AND \"Evidencija_Skladista\".\"evidencija_datum\"" +
                "BETWEEN '" + datumpocetak + "'  AND'" + datumkraj + "' ;";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobilDs = new DataSet();

            dataAdapter.Fill(automobilDs);

            dgvEvidencija.DataSource = automobilDs.Tables[0];
        }

        private void dtpKraj_ValueChanged(object sender, EventArgs e)
        {
            datumpocetak = dtpPocetak.Value.ToString("yyyy-MM-dd HH:mm:ss");
            datumkraj = dtpKraj.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string sql =
                "SELECT \"Evidencija_Skladista\".\"evidencija_datum\", \"Evidencija_Skladista\".\"prijasnja_kolicina\", \"Evidencija_Skladista\".\"nova_kolicina\", \"Evidencija_Skladista\".\"tip_posla\"," + "" +
                "\"Automobil\".\"naziv\" FROM \"Evidencija_Skladista\",\"Automobil\" WHERE \"Evidencija_Skladista\".\"fk_automobil\" = \"Automobil\".\"id\" AND \"Evidencija_Skladista\".\"evidencija_datum\"" +
                "BETWEEN '" + datumpocetak + "'  AND'" + datumkraj + "' ;";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, baza.connection);
            DataSet automobilDs = new DataSet();

            dataAdapter.Fill(automobilDs);

            dgvEvidencija.DataSource = automobilDs.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kljuc = int.Parse(txtFkAutomobil.Text.ToString());

            if (kljuc > 0)
            {
                baza.Povezi();
                string sql = "DELETE FROM \"Stanje_Na_Skladistu\" WHERE \"Stanje_Na_Skladistu\".\"fk_automobil\" = " + kljuc + " ;";

                NpgsqlCommand command = new NpgsqlCommand(sql, baza.connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "UPOZORENJE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Osvjezi(baza.connection);
                Osvjezi_Evidenciju(baza.connection);
                baza.Odspoji();
            }
            else
            {
                MessageBox.Show("Molim Vas odaberite automobil koji želite obrisati", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        

    }
    }
}
