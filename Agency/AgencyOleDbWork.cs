using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace Agency
{
    class AgencyOleDbWork
    {
        protected static OleDbConnection connect = null;
        protected string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AgencyDB.mdb";

        public void OpenConnection()
        {
            try
            {
                connect = new OleDbConnection(connectionString);
                connect.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void CloseConnection()
        {
            try
            {
                connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        public void InsertObject(string typeBilding, string address, int floor, int floorCount, int totalArea, int livingArea, int kitchenArea, string typeStove, 
                                string typeBathroom, string bath, string hotWater, int roomCount, int isolatedRooms, int adjacentRooms, int loggias, int balcony, double price)
        {
            try
            {
                string sql = string.Format("INSERT INTO Нерухомість" + "(ТипБудинку, Адреса, Поверх, ВсьогоПоверхів, ЗагальнаПлоща, ЖитловаПлоща, ПлощаКухні, ТипПлити, ТипСанузла, Ванна, ГарячаВода, КількістьКімнат, ІзольованіКімнати, СуміжніКімнати, Лоджі, Балкони, Ціна) Values(@ТипБудинку, @Адреса, @Поверх, @ВсьогоПоверхів, @ЗагальнаПлоща, @ЖитловаПлоща, @ПлощаКухні, @ТипПлити, @ТипСанузла, @Ванна, @ГарячаВода, @КількістьКімнат, @ІзольованіКімнати, @СуміжніКімнати, @Лоджі, @Балкони, @Ціна)");

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@ТипБудинку", typeBilding);
                    cmd.Parameters.AddWithValue("@Адреса", address);
                    cmd.Parameters.AddWithValue("@Поверх", floor);
                    cmd.Parameters.AddWithValue("@ВсьогоПоверхів", floorCount);
                    cmd.Parameters.AddWithValue("@ЗагальнаПлоща", totalArea);
                    cmd.Parameters.AddWithValue("@ЖитловаПлоща", livingArea);
                    cmd.Parameters.AddWithValue("@ПлощаКухні", kitchenArea);
                    cmd.Parameters.AddWithValue("@ТипПлити", typeStove);
                    cmd.Parameters.AddWithValue("@ТипСанузла", typeBathroom);
                    cmd.Parameters.AddWithValue("@Ванна", bath);
                    cmd.Parameters.AddWithValue("@ГарячаВода", hotWater);
                    cmd.Parameters.AddWithValue("@КількістьКімнат", roomCount);
                    cmd.Parameters.AddWithValue("@ІзольованіКімнати", isolatedRooms);
                    cmd.Parameters.AddWithValue("@СуміжніКімнати", adjacentRooms);
                    cmd.Parameters.AddWithValue("@Лоджі", loggias);
                    cmd.Parameters.AddWithValue("@Балкони", balcony);
                    cmd.Parameters.AddWithValue("@Ціна", price);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Нова інформація успішно додана");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void DeleteObject(int id)
        {
            try 
            {
                string sql = string.Format("DELETE FROM Нерухомість WHERE [КодНерухомості]= @id");
                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();                   
                }
                MessageBox.Show("Видалено!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                       
        }

        public void InsertClient(string surname, string name, string patronymic, string phone)
        {
            try 
            {
                string sql = string.Format("INSERT INTO Клієнти" + "(Прізвище, Імя, ПоБатькові, Телефон) Values(@Прізвище, @Імя, @ПоБатькові, @Телефон)");

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@Прізвище", surname);
                    cmd.Parameters.AddWithValue("@Імя", name);
                    cmd.Parameters.AddWithValue("@ПоБатькові", patronymic);
                    cmd.Parameters.AddWithValue("@Телефон", phone);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Нова інформація успішно додана");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }

        public void DeleteClient(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM Клієнти WHERE [КодКлієнта]= @id");
                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Видалено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                   
        }

        public void InsertContract(int objectID, int clientID, int workerID, string conclusionDate, string expirationDate)
        {
            try
            {
                string sql = string.Format("INSERT INTO Договори" + "(КодНерухомості, КодКлієнта, КодПрацівника, ДатаЗаключення, ДатаЗавершення) Values(@КодНерухомості, @КодКлієнта, @КодПрацівника, @ДатаЗаключення, @ДатаЗавершення)");

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@КодНерухомості", objectID);
                    cmd.Parameters.AddWithValue("@КодКлієнта", clientID);
                    cmd.Parameters.AddWithValue("@КодПрацівника", workerID);
                    cmd.Parameters.AddWithValue("@ДатаЗаключення", conclusionDate);
                    cmd.Parameters.AddWithValue("@ДатаЗавершення", expirationDate);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Нова інформація успішно додана");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void DeleteContract(int id)
        {
            try 
            {
                string sql = string.Format("DELETE FROM Договори WHERE [КодДоговору]= @id");

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Видалено!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void InsertWorker(string surname, string name, string patronymic, string birthDate, string position, double salary)
        {
            try 
            {
                string sql = string.Format("INSERT INTO Працівники" + "(Прізвище, Імя, ПоБатькові, ДатаНародження, Посада, Зарплата) Values(@Прізвище, @Імя, @ПоБатькові, @ДатаНародження, @Посада, @Зарлата)");

                using (OleDbCommand cmd = new OleDbCommand(sql, connect)) 
                {
                    cmd.Parameters.AddWithValue("@Прізвище", surname);
                    cmd.Parameters.AddWithValue("@Імя", name);
                    cmd.Parameters.AddWithValue("@ПоБатькові", patronymic);
                    cmd.Parameters.AddWithValue("@ДатаНародження", birthDate);
                    cmd.Parameters.AddWithValue("@Посада", position);
                    cmd.Parameters.AddWithValue("@Зарплата", salary);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Нова інформація успішно додана");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public void DeleteWorker(int id)
        {
            try 
            {
                string sql = string.Format("DELETE FROM Працівники WHERE [КодПрацівника]= @id");
                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Видалено!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public DataTable GetObjectsAsDataTable()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM Нерухомість";
            using (OleDbCommand cmd = new OleDbCommand(sql, connect))
            {
                try 
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    table.Load(dr);
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            return table;           
        }

        public DataTable GetClientsAsDataTable()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM Клієнти";
            using (OleDbCommand cmd = new OleDbCommand(sql, connect))
            {
                try
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    table.Load(dr);
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }              
            }
            return table;
        }

        public DataTable GetContractsAsDataTable()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM Договори";      
            using (OleDbCommand cmd = new OleDbCommand(sql, connect))
            {
                try
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    table.Load(dr);
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            return table;
        }

        public DataTable GetWorkersAsDataTable()
        {
            DataTable table = new DataTable();
            string sql = "SELECT * FROM Працівники";
            using (OleDbCommand cmd = new OleDbCommand(sql, connect))
            {
                try
                {
                    OleDbDataReader dr = cmd.ExecuteReader();
                    table.Load(dr);
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            return table;
        }

        public void BindObjectsComboBox(ComboBox comboBoxName)
        {
            try
            {
                string sql = "SELECT КодНерухомості FROM Нерухомість";
                DataSet ds = new DataSet();
                OpenConnection();

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds, "Нерухомість");

                        comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                        comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["КодНерухомості"].ToString();
                        comboBoxName.SelectedValuePath = ds.Tables[0].Columns["КодНерухомості"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindClientsComboBox(ComboBox comboBoxName)
        {
            try
            {
                string sql = "SELECT КодКлієнта FROM Клієнти";
                DataSet ds = new DataSet();
                OpenConnection();

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    try
                    {                      
                        da.Fill(ds, "Клієнти");
                       
                        comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                        comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["КодКлієнта"].ToString();
                        comboBoxName.SelectedValuePath = ds.Tables[0].Columns["КодКлієнта"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindWorkersComboBox(ComboBox comboBoxName)
        {
            try
            {
                string sql = "SELECT КодПрацівника FROM Працівники";
                DataSet ds = new DataSet();
                OpenConnection();

                using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    try
                    {
                        da.Fill(ds, "Працівники");

                        comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                        comboBoxName.DisplayMemberPath = ds.Tables[0].Columns["КодПрацівника"].ToString();
                        comboBoxName.SelectedValuePath = ds.Tables[0].Columns["КодПрацівника"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}
