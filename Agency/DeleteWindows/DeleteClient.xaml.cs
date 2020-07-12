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
    
    public partial class DeleteClient : Window
    {
        private static DeleteClient del_client = null;       
        AgencyOleDbWork aodw = new AgencyOleDbWork();       
        private DeleteClient()
        {
            InitializeComponent();
        }

        public static DeleteClient GetDeleteClient()
        {
            if(del_client == null)
            {
                del_client = new DeleteClient();
            }
            del_client.Activate();
            return del_client;
        }
       
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                Close();
                aodw.OpenConnection();
                aodw.DeleteClient(id);
                aodw.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                      
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            del_client = null;
        }
    }
}
