using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ejercicio001;
using System.Text.RegularExpressions;

namespace Ejercicio001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //instanciasr base de datos

            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtsueldo.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                Empleado emp = new Empleado();
                emp.Nombre = txtnombre.Text;
                emp.Sueldo = int.Parse(txtsueldo.Text);
                db.Empleados.Add(emp);
                db.SaveChanges();
            }
            else {
                MessageBox.Show("INGRESE BIEN LOS DATOS");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtsueldo.Text, @"^\d+$")){

            demoEF db= new demoEF();
            int id = int.Parse(txtid.Text);
            var emp = db.Empleados.SingleOrDefault(x => x.id == id);
            if (emp != null)
            {
                emp.Nombre = txtnombre.Text;
                emp.Sueldo = int.Parse(txtsueldo.Text);
                db.SaveChanges();
            }
            else {
                MessageBox.Show("INGRESE BIEN LOS DATOS");
            }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {

                demoEF db = new demoEF();
                int id = int.Parse(txtid.Text);
                var emp = db.Empleados.SingleOrDefault(x => x.id == id);
                if (emp != null)
                {
                    db.Empleados.Remove(emp);
                    db.SaveChanges();
                }
            }
            else {
                MessageBox.Show("SOLO NUMEROS");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                demoEF db = new demoEF();
                int id = int.Parse(txtid.Text);
                var registros = from s in db.Empleados
                                where s.id == id
                                select new
                                {
                                    s.Nombre,
                                    s.Sueldo
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else {
                MessageBox.Show("Ingresa solo numeros bay");
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            demoEF db = new demoEF();
            var registros = from s in db.Empleados

                            select s;
              
            dbgrid.ItemsSource = registros.ToList();
        }

        private void txtid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
