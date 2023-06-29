using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrizP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Matriz m1,m2;
        private void Form1_Load(object sender, EventArgs e)
        {
            m1 = new Matriz();          
            m2 = new Matriz();
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox5.Text = m1.Descargar();
        }

        private void acumularElementosPrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.AcumularConPrimo());
        }

        private void frecuenciaDeUnElementoEnLaMatrizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.FrecuenciaDeUnElemento(int.Parse(textBox9.Text)));
        }

        private void contarElementosQueNoSeRepitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.ContarEleQueNoSeRepiten());
        }

        private void cargarSerieFibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.CargarSerieFibonacci(int.Parse(textBox1.Text),int.Parse(textBox2.Text));
            textBox5.Text = m1.Descargar();         
        }

        private void verificarSiLasFilasEstanOrdenasAscendentementeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.VerificarSiLasFilasEstanOrdenadas());
        }

        private void rigorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.VerificarSiEstaOrdenadaConRigor(int.Parse(textBox10.Text)));
        }

        private void segmentarParesYNoParesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.SegmentarFilasEnParesImpares();
            textBox8.Text = m1.Descargar();
        }

        private void ordenarFilasPorElNúmeroDePrimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.OrdFilasPorCantPrimos();
            textBox8.Text = m1.Descargar();
        }

        private void cargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m2.Cargar(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
        }

        private void descargarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox6.Text = m2.Descargar();
        }

        private void encontrarElElementoConMayorFrecuenciaDeCadaFilaYAñadirCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.MayorFrecuenciaUltimaColumna();
            textBox8.Text = m1.Descargar();
        }

        private void ordenamientoSenozoidalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m1.OrdenarMatrizSenozoidal();
            textBox8.Text = m1.Descargar();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            m1.OrdenarPorFrecuenciaSecuencia();
            textBox8.Text = m1.Descargar();
        }

        private void verificarSiUnaMatrizEstaIncluidaEnOtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox8.Text = string.Concat(m1.VerificarSiUnaMatrizEstaEnOtra(m2));
        }
    }
}
