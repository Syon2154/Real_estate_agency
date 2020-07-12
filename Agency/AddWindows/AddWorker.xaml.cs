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
using System.Windows.Shapes;
using System.Data.OleDb;

namespace Agency
{
    
    public partial class AddWorker : Window
    {
        private static AddWorker add_worker = null;        
        AgencyOleDbWork aodw = new AgencyOleDbWork();
        
        private AddWorker()
        {
            InitializeComponent();
        }

        public static AddWorker GetAddWorker()
        {
            if (add_worker == null)
            {
                add_worker = new AddWorker();
            }
            add_worker.Activate();
            return add_worker;
        }
       
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                DateTime rowBirthDate = calendar1.SelectedDate.GetValueOrDefault();
                string birthDate = rowBirthDate.ToShortDateString();  
                
                aodw.OpenConnection();
                aodw.InsertWorker(textBox1.Text, textBox2.Text, textBox3.Text, birthDate, textBox4.Text, Convert.ToDouble(textBox5.Text));
                aodw.CloseConnection();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();            
            textBox4.Clear();
            textBox5.Clear();
            calendar1.DisplayDate = DateTime.Today;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            add_worker = null;
        }
    }
}
