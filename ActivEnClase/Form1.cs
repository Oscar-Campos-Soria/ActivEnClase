using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivEnClase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Persona
        {
            public NombrePersona Nombre { get; set; }
            public DateTime FechaNacimiento { get; set; }

            public override string ToString()
            {
                return $"{Nombre}, Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}";
            }
        }

        public class NombrePersona
        {
            public string Nombre { get; set; }
            public string ApellidoPaterno { get; set; }
            public string ApellidoMaterno { get; set; }

            public override string ToString()
            {
                return $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
            }
        }

        public class Estudiante : Persona
        {
            public string Matricula { get; set; }
            public string Carrera { get; set; }
            public double Promedio { get; set; }

            public override string ToString()
            {
                // Se utiliza la propiedad Nombre de la clase base Persona
                string nombreCompleto = $"{Nombre.Nombre} {Nombre.ApellidoPaterno} {Nombre.ApellidoMaterno}";
                return $"Nombre: {nombreCompleto}, Matrícula: {Matricula}, Carrera: {Carrera}, Promedio: {Promedio}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados por el usuario
            string nombre = txtNombre.Text;
            string apellidoPaterno = txtApellidoPaterno.Text;
            string apellidoMaterno = txtApellidoMaterno.Text;
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            string matricula = txtMatricula.Text;
            string carrera = txtCarrera.Text;
            double promedio = Convert.ToDouble(numericUpDown1.Text);

            // Crear objeto de la clase Estudiante
            Estudiante estudiante = new Estudiante
            {
                Nombre = new NombrePersona
                {
                    Nombre = nombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno
                },
                FechaNacimiento = fechaNacimiento,
                Matricula = matricula,
                Carrera = carrera,
                Promedio = promedio
            };

            // Agregar el estudiante al ListBox
            listBox1.Items.Add(estudiante.ToString());

            // Limpiar los campos después de agregar un estudiante
            LimpiarCampos();
        }

        // Método para limpiar los campos después de agregar un estudiante
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtMatricula.Clear();
            txtCarrera.Clear();
            dtpFechaNacimiento.Value = DateTime.Now; // Restablecer a la fecha y hora actuales
        }
    }
}