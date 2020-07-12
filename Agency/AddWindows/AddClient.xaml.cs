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
    
    public partial class AddClient : Window
    {
        private static AddClient add_client = null;
        AgencyOleDbWork aodw = new AgencyOleDbWork();          
        private AddClient()
        {
            InitializeComponent();
        }

        public static AddClient GetAddClient()
        {
            if(add_client == null)
            {
                add_client = new AddClient();
            }
            add_client.Activate();
            return add_client;
        }
        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {               
                aodw.OpenConnection();
                aodw.InsertClient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
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
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            add_client = null;
        }
    }
}
