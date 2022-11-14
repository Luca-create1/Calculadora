using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    //Paso 16. Agreagamos un enum para las diferentes tipos de operaciones que pueda tener un dato
    //Son las operaciones que tiene esta calculadora
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5,
    }
    public partial class Form1 : Form
    {
        //Paso 13
        double valor1 = 0;
        //Paso 14. Para que concrete la suma, declaramos otra variable
        double valor2 = 0;
        //Paso 17. Crear una variable de tipo numerador. Comienza como noDefinidad
        Operacion operador = Operacion.NoDefinida;
        //Paso 30. Variable, para que cuando el usuario presione = al comienzo
        // no siga sumando los 0= + 0= ....
        bool unNumeroLeido = false; //El usuario no ha ingresado un numero
        public Form1()
        {
            InitializeComponent();
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        //Paso 1
        // Reutilizamos codigo,creando este método

        private void LeerNumero(string numero)
        {
            //Paso 33. 
            unNumeroLeido=true; //cuando se lea un numero se convierte en true
             //En caja resultado quiero colocarle un valor a 0 y va a comenzar en 0 tambien
            if (cajaResultado.Text == "0" && cajaResultado.Text != null)
            {
                cajaResultado.Text = numero;

            }
            else
            {
                cajaResultado.Text += numero;

            }

         
        }


        //Paso 15. Hacer un método para que el resultado pueda lanzar, el 
        // resultado de +,-,x, / 

        private double EjecutarOperacion()
        {

            double resultado = 0;
            switch (operador)
            {

                //Paso 15.
                //case "+":
                //resultado = valor1 + valor2;
                //    break;

                //case "-":
                //resultado = valor1 - valor2;
                //    break;

                //Paso 25. Completar los demas case con las otras operaciones

                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;

                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;

                case Operacion.Division:
                    //Como no se puede dividir por 0, hacemos lo siguiente
                    if(valor2 == 0)
                    {
                        //MessageBox.Show("No se puede dividir entre 0 ");
                        lblHistorial.Text = "No se puede dividir entre 0";
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                     break;

                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;

                case Operacion.Modulo:
                    resultado = valor1 % valor2;
                    break;
            }
            return resultado;
        }
        //Paso 2
        //Botón 0 
        private void btnCero_Click(object sender, EventArgs e)
        {
            //paso 32, unNumeroLeido, se leyo x los menos un numero

            unNumeroLeido = true;
            LeerNumero("0");
        }

        //Paso 3
        //Botón 1
        private void btnUno_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        //Paso 4
        private void btnTres_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }


        //Paso 5
        private void btnCuatro_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        //Paso 6
        private void btnCinco_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }


        //Paso 7
        private void btnSeis_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }


        //Paso 8
        private void btnSiete_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }


        //Paso 9
        private void btnOcho_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }


        //Paso 10
        private void btnNueve_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        //Paso 11
        private void btnDos_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        //Paso 19 Utilizamos el mismo codigo que habia suma aqui
        private void ObtenerValor (string operador)
        {
            valor1 = Convert.ToDouble(cajaResultado.Text);
            lblHistorial.Text = cajaResultado.Text + operador;
            cajaResultado.Text = "0";

        }
        //Paso 12
        private void btnSuma_Click(object sender, EventArgs e)
        {
             //Paso 18. Cuando queramos sumar,vamos a decir que nuestro operador es una suma
            operador = Operacion.Suma;
            //Paso 20. Obtengo el valor y lleno el historial
            ObtenerValor("+");
            //// Paso 12. Primero se escribe, luego se utiliza el mismo codigo en otro lado
            ///El numero que este en la caja lo convertimos a un valor
            //valor1 = Convert.ToDouble(cajaResultado.Text);
            ////Luego a nuestro historial, lo que tenga + el valor
            //lblHistorial.Text = cajaResultado.Text + "+";
            ////Regrese a 0 la caja de resultado para que espere un valor
            //cajaResultado.Text = "0";
        }

        //Paso 14
        private void btnResultado_Click(object sender, EventArgs e)
        {
            //Valor 2 esta vacio
            //Esto es para sumar
            //Paso 31. un numero leido
            if (valor2 == 0 && unNumeroLeido)
            {
                //Valor 2 va ser double
                valor2 = Convert.ToDouble(cajaResultado.Text);
                //Al historial le vamos apilar el valor 2 + e igual 
                lblHistorial.Text += valor2 + "=";
                //Variable resultado para sumar ambos valores
                double resultado = EjecutarOperacion();
                //Que a los valores lo igualamos a 0 porque no vamos a hacer mas nada
                valor1 = 0;
                valor2 = 0;
                unNumeroLeido = false; // Si se cumple
                //Que se muestre
                cajaResultado.Text = Convert.ToString(resultado);

            }
        }

        //Paso 21. La resta. Para que la resta funcione en el historial, pero no tira un
        // resultado restado. Idem para 22,23,24. Xq no se hizo nada en el 
        //Boton =

        private void btnResta_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ObtenerValor("-");
        }

        //Paso 22. Multiplicacion
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ObtenerValor("x");
        }

        //Paso 23. Division
        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ObtenerValor("/");
        }

        //Paso 24. Modulo
        private void btnModulo_Click(object sender, EventArgs e)
        {
            operador = Operacion.Modulo;
            ObtenerValor("%");
        }


        //Paso 26. Boton borrar
        private void btnReset_Click(object sender, EventArgs e)
        {
            cajaResultado.Text = "0";
            lblHistorial.Text = "";
        }

        //Paso 27. Boton borrar numero x numero
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(cajaResultado.Text.Length > 1)
            {
                string txtResultado = cajaResultado.Text;
                // Ej: N° 1000, presiono CE queda en 100, presiono otra vez y queda en 10
                //Presiono otra vez queda en 1, y si presiono otra vez se convierte en 0
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                //Paso 28. Controlar el boton CE
                //Ej: N° -1 y presiono CE no se romperia el programa, se convierte
                // en N° 0.
                if ( txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    cajaResultado.Text = "0";
                }
                else
                {

                    cajaResultado.Text = txtResultado;

                }
            }
            else 
            {
                cajaResultado.Text = "0";
            }
        }


        //Paso 29. Boton . (decimal)
        private void btnPunto_Click(object sender, EventArgs e)
        {
            //Si caja resultado contiene un .
            //Contains ---> Contiene
            if(cajaResultado.Text.Contains("."))
            {
                return;

            }
            cajaResultado.Text += ".";
        }
    }
}
