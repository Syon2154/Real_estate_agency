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
    
    public partial class AddContract : Window
    {
        private static AddContract add_contract = null;        
        AgencyOleDbWork aodw = new AgencyOleDbWork();       
        private AddContract()
        {
            InitializeComponent();
            aodw.BindObjectsComboBox(comboBox1);
            aodw.BindClientsComboBox(comboBox2);
            aodw.BindWorkersComboBox(comboBox3);
        }

        public static AddContract GetAddContract()
        {
            if(add_contract == null)
            {
                add_contract = new AddContract();
            }
            add_contract.Activate();
            return add_contract;
        }
                    
            private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int objectID = Convert.ToInt32(comboBox1.Text);
                int clientID = Convert.ToInt32(comboBox1.Text);
                int workerID = Convert.ToInt32(comboBox1.Text);
                
                DateTime rowConclusionDate = calendar1.SelectedDate.GetValueOrDefault();
                DateTime rowExpirationDate = calendar2.SelectedDate.GetValueOrDefault();
                string conclusionDate = rowConclusionDate.ToShortDateString();
                string expirationDate = rowConclusionDate.ToShortDateString();

                aodw.OpenConnection();
                aodw.InsertContract(objectID, clientID, workerID, conclusionDate, expirationDate);
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            calendar1.DisplayDate = DateTime.Today;
            calendar2.DisplayDate = DateTime.Today;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            add_contract = null;
        }
    }
}
