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
    
    public partial class DeleteObject : Window
    {
        private static DeleteObject del_object = null;       
        AgencyOleDbWork aodw = new AgencyOleDbWork();       
        private DeleteObject()
        {
            InitializeComponent();
        }

        public static DeleteObject GetDeleteObject()
        {
            if(del_object == null)
            {
                del_object = new DeleteObject();
            }
            del_object.Activate();
            return del_object;
        }
       
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                Close();
                aodw.OpenConnection();
                aodw.DeleteObject(id);               
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
            del_object = null;
        }
    }
}
