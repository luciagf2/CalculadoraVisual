using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraVisual
{
    public partial class Form1 : Form
    {
        Boolean primera = true; //Está a true si es la primera vez que se hace una operación (se pulsa un "+", "-"... )
        Boolean nuevo = true; //Está a true si es el primer número que se pulsa, bien la primera vez que se introduce un número o después de hacer una operación y que nos haya dado el resultado
        String operador = null;
        double resultado = 0;
        double num1, num2, memoria = 0;
        Boolean coma = false;
        Boolean unaria = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region //NÚMEROS, IGUAL Y COMA

        private void button1_Click(object sender, EventArgs e)
        {
            numerosbtn(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numerosbtn(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numerosbtn(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numerosbtn(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numerosbtn(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numerosbtn(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numerosbtn(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numerosbtn(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numerosbtn(button9.Text);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (nuevo)
            {
                TBAbajo.Text = "";
                TBAbajo.Text = button0.Text;
                nuevo = false;
            }
            else if (TBAbajo.Text == "0")
            {

            }
            else
            {
                TBAbajo.Text += button0.Text;
            }
        }

        private void igual_Click(object sender, EventArgs e)
        {
            num2 = int.Parse(TBAbajo.Text);
            TBArriba.Text = "";
            resultado = Operando(num1, operador, num2);
            TBAbajo.Text = resultado.ToString();
            resultado = num1;
            primera = true;
        } 
        
        private void buttoncoma_Click(object sender, EventArgs e)
        {
            if (!nuevo)
            {
               if (coma)
                {
                    TBAbajo.Text += buttoncoma.Text;
                    coma = false;
                }
            }
        }

#endregion

        #region //OPERACIONES

        private void buttonmas_Click(object sender, EventArgs e)
        {
            String y = buttonmas.Text;
            operacionesbinarias(y);
        }

        private void buttonmenos_Click(object sender, EventArgs e)
        {
           String y = buttonmenos.Text;
           operacionesbinarias(y);
        }

        private void buttonpor_Click(object sender, EventArgs e)
        {
            String y = buttonpor.Text;
            operacionesbinarias(y);
        }

        private void buttondiv_Click(object sender, EventArgs e)
        {
            String y = buttondiv.Text;
            operacionesbinarias(y);
        }

        #endregion

        #region //MÉTODOS

        static double Operando(double NumUno, string operador, double NumDos)
        {
            double resultado = 0.0;

            switch (operador)
            {
                case "+":
                    resultado = NumUno + NumDos;
                    break;
                case "-":
                    resultado = NumUno - NumDos;
                    break;
                case "*":
                    resultado = NumUno * NumDos;
                    break;
                case "/":
                    resultado = NumUno / NumDos;
                    break;
            }
            return resultado;
        }

        public void operacionesbinarias (String y)
        {
             if (primera)
            {
                operador = y;
                num1 = double.Parse(TBAbajo.Text);
                TBArriba.Text += (num1 + operador);
                TBAbajo.Text = "";
                primera = false;
            }
            else
            {
                num2 = double.Parse(TBAbajo.Text);
                resultado = Operando(num1, operador, num2);
                operador = y;
                TBArriba.Text += (TBAbajo.Text + operador);
                TBAbajo.Text = resultado.ToString();
                num1 = resultado;
                nuevo = true;
            }
        }

        public void numerosbtn(String x)
        {
            if (nuevo)
            {
                TBAbajo.Text = "";
                TBAbajo.Text = x;
                nuevo = false;
                coma = true;
            }
            else if (TBAbajo.Text == "0")
            {
                TBAbajo.Text = "";
                TBAbajo.Text += x;
            }
            else
            {
                TBAbajo.Text += x;
            }
        }

        #endregion

        #region //BOTONES ESPECIALES


        private void buttonMC_Click(object sender, EventArgs e)
        {
            memoria = 0;
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            TBAbajo.Text = memoria.ToString();
            TBArriba.Text = "";
            num1 = memoria;
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            memoria = double.Parse(TBAbajo.Text);
            TBAbajo.Text = "";
        }

        private void buttonMmas_Click(object sender, EventArgs e)
        {
            memoria += double.Parse(TBAbajo.Text);
            TBAbajo.Text = "";
        }

        private void buttonMmenos_Click(object sender, EventArgs e)
        {
            memoria -= double.Parse(TBAbajo.Text);
            TBAbajo.Text = "";
        }

        private void buttonmasmenos_Click(object sender, EventArgs e)
        {
            double numero = double.Parse(TBAbajo.Text);
            numero = -numero;
            TBAbajo.Text = numero.ToString();
        }

        private void buttonbordig_Click(object sender, EventArgs e)
        {
            if (TBAbajo.Text.Length > 1)
            {
                TBAbajo.Text = TBAbajo.Text.Remove(TBAbajo.Text.Length - 1);
            }
            else
            {
                TBAbajo.Text = "0";
            }
            if ((TBAbajo.Text).IndexOf(',') == -1)
            {
                coma = true;
            }
        }

        private void buttonbornum_Click(object sender, EventArgs e)
        {
            TBAbajo.Text = "0";
            coma = true;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            TBAbajo.Text = "0";
            TBArriba.Text = "";
            resultado = 0;
            memoria = 0;
            coma = true;
        }
        #endregion

    }
}
