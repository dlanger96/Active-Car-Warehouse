using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tbp_projekt
{
    public partial class Skladiste_Automobila_Izbornik : Form
    {
        public Skladiste_Automobila_Izbornik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrikazSkladista prikazSkladista = new PrikazSkladista();
            prikazSkladista.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Automobili automobili = new Automobili();
            automobili.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajAutomobil dodaj = new DodajAutomobil();
            dodaj.Show();
        }

        private void btnNabavaNarudzbenica_Click(object sender, EventArgs e)
        {
             NabavaINarudzbenica nabNar = new NabavaINarudzbenica();
            nabNar.Show();
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            StatistikaProizvodaci stat = new StatistikaProizvodaci();
            stat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StatistikaGorivo gorivo = new StatistikaGorivo();
            gorivo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StatistikaNarucivanja narucivanje = new StatistikaNarucivanja();
            narucivanje.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
