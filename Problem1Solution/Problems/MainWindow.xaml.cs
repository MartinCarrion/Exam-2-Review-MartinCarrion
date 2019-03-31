//Using the Employees.txt file, read in the file and show a list of all the employees that make
//over 70,000 in salary.In a separate list, display all of the employees that have an email
//address at dropbox.com.When reading in the file, save the values in a class that has
//constructors as well as an overridden ToString method.Output the average salary for all of
//the employees as well.
//a.
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Problems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> emps = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
           // DO THIS if Below does not work string downloadsDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads
            dlg.InitialDirectory = @"C:\Users\Martin\Desktop\";
            var Result=dlg.ShowDialog();
            if (Result==true)
            {
                txtSelect.Text = dlg.FileName;

            }

        }

        private void BtnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            
            if (File.Exists(txtSelect.Text))
            {
               var lines= File.ReadAllLines(txtSelect.Text);
                int Count = 0;
                foreach (var line in lines)
                {
                    if (Count!=0)
                    {
                        var linePieces = line.Split('|');
                        string firstname, lastname, email, gender;
                        double salary;

                        firstname = linePieces[0];
                        lastname = linePieces[1];
                        email= linePieces[2];
                        gender= linePieces[3];
                        salary = Convert.ToDouble(linePieces[4].Replace("$", " "));

                        Employee emp = new Employee(firstname, lastname, email, gender, salary);
                        emps.Add(emp);
                    }
                    Count++;

                }

                EmployeesWithGreaterThanSeventyK();
                EmployeesWithEmailDropbox();



            }






        }
        private void EmployeesWithEmailDropbox()
        {
            foreach (var emp in emps)
            {
                if (emp.Email.Contains("@dropbox.com"))
                {
                    lst_Emails.Items.Add(emp);
                }

            }
            MessageBox.Show(emps.Count().ToString() + " Employees That have over $70,000");

        }

        private void EmployeesWithGreaterThanSeventyK()
        {
            foreach (var emp in emps)
            {
                if (emp.Salary > 70000 )
                {
                    
                    lstSalaries.Items.Add(emp);
                    

                    
                }

                

            }
        }


    }
}
