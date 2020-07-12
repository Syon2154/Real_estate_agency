
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Agency
{
    public partial class MainWindow : Window
    {      
        AgencyOleDbWork aodw = new AgencyOleDbWork();
        AddObject add_object = null;
        DeleteObject del_object = null;
        AddClient add_client = null;
        DeleteClient del_client = null;
        AddContract add_contract = null;
        DeleteContract del_contract = null;
        AddWorker add_worker = null;
        DeleteWorker del_worker = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Ви підтверджуєте вихід?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
               if(add_object != null)
                {
                    add_object.Close();
                }

               if(del_object != null)
                {
                    del_object.Close();
                }

               if(add_client != null)
                {
                    add_client.Close();
                }

               if(del_client != null)
                {
                    del_client.Close();
                }

               if(add_contract != null)
                {
                    add_contract.Close();
                }

               if( del_contract != null)
                {
                    del_contract.Close();
                }

               if(add_worker != null)
                {
                    add_worker.Close();
                }

               if(del_worker != null)
                {
                    del_worker.Close();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        
        //Об'єкти нерухомості
        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            add_object = AddObject.GetAddObject();
            add_object.Show();
        }

        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {
            del_object = DeleteObject.GetDeleteObject();
            del_object.Show();
        }

        private void LookAllObjects_Click(object sender, RoutedEventArgs e)
        {
            aodw.OpenConnection();
            dataGrid.ItemsSource = aodw.GetObjectsAsDataTable().DefaultView;
            aodw.CloseConnection();
            
        }

        //Клієнти
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {            
            add_client = AddClient.GetAddClient();
            add_client.Show();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            del_client = DeleteClient.GetDeleteClient();
            del_client.Show();
        }

        private void LookAllClients_Click(object sender, RoutedEventArgs e)
        {
            aodw.OpenConnection();
            dataGrid.ItemsSource = aodw.GetClientsAsDataTable().DefaultView;
            aodw.CloseConnection();
        }

        //Договори
        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            add_contract = AddContract.GetAddContract();
            add_contract.Show();
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            del_contract = DeleteContract.GetDeleteContract();
            del_contract.Show();
        }

        private void LookAllContracts_Click(object sender, RoutedEventArgs e)
        {
            aodw.OpenConnection();
            dataGrid.ItemsSource = aodw.GetContractsAsDataTable().DefaultView;
            aodw.CloseConnection();
        }

        //Працівники
        private void AddWorker_Click(object sender, RoutedEventArgs e)
        {
            add_worker = AddWorker.GetAddWorker();
            add_worker.Show();
        }

        private void DeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            del_worker = DeleteWorker.GetDeleteWorker();
            del_worker.Show();
        }

        private void LookAllWorkers_Click(object sender, RoutedEventArgs e)
        {
            aodw.OpenConnection();
            dataGrid.ItemsSource = aodw.GetWorkersAsDataTable().DefaultView;
            aodw.CloseConnection();
        }

        //Пошук
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<object> list1 = null;
                       
            foreach (DataRowView row in dataGrid.ItemsSource)
            {
                list1 = row.Row.ItemArray.Cast<object>().ToList();
                
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].ToString() == searchBox.Text)
                    {
                        (dataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow).Background = Brushes.Green;
                    }
                }                                           
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {           
            foreach (DataRowView row in dataGrid.ItemsSource)
            {               
                for (int i = 0; i < dataGrid.Items.Count; i++)
                {                    
                    (dataGrid.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow).Background = Brushes.White;
                }
            }
        }
    }
}
            
        
        
