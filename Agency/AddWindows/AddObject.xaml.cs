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
    
    public partial class AddObject : Window
    {
        private static AddObject add_object = null;       
        AgencyOleDbWork aodw = new AgencyOleDbWork();
        
        private AddObject()
        {
            InitializeComponent();
        }

        public static AddObject GetAddObject()
        {
            if(add_object == null)
            {
                add_object = new AddObject();
            }
            add_object.Activate();
            return add_object;
        }
       
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                aodw.OpenConnection();
                aodw.InsertObject(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), textBox8.Text, textBox9.Text,
                textBox10.Text, textBox11.Text, Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox15.Text), Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox17.Text));
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";
            textBox16.Text = "0";           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            add_object = null;
        }
    }
}
