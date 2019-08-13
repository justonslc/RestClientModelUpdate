using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestClientModel.Models;
using MySql.Data;
using System.Collections;

namespace RestClientModel
{
    public class PropertyPersistence
    {

        Connections connections = new Connections();
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public ArrayList GetProperty()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList propertyArray = new ArrayList();

                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblproperty";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Property p = new Property();
                    p.ID = mySqlDataReader.GetInt32(0);
                    p.ComputerMake = mySqlDataReader.GetString(1);
                    p.ComputerModel = mySqlDataReader.GetString(2);
                    p.Processor = mySqlDataReader.GetString(3);
                    p.IssueDate = mySqlDataReader.GetDateTime(4);
                    p.SerialNumber = mySqlDataReader.GetString(5);
                    p.Ram = mySqlDataReader.GetInt16(6);
                    p.HardDrive = mySqlDataReader.GetInt16(7);
                    p.CellPhoneMake = mySqlDataReader.GetString(8);
                    p.CellPhoneModel = mySqlDataReader.GetString(9);
                    p.CellPhoneNumber = mySqlDataReader.GetDouble(10);

                    propertyArray.Add(p);
                }
                return propertyArray;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public Property GetProperty(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList propertyArray = new ArrayList();
                Property p = new Property();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblproperty WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    p.ID = mySqlDataReader.GetInt32(0);
                    p.ComputerMake = mySqlDataReader.GetString(1);
                    p.ComputerModel = mySqlDataReader.GetString(2);
                    p.Processor = mySqlDataReader.GetString(3);
                    p.IssueDate = mySqlDataReader.GetDateTime(4);
                    p.SerialNumber = mySqlDataReader.GetString(5);
                    p.Ram = mySqlDataReader.GetInt16(6);
                    p.HardDrive = mySqlDataReader.GetInt16(7);
                    p.CellPhoneMake = mySqlDataReader.GetString(8);
                    p.CellPhoneModel = mySqlDataReader.GetString(9);
                    p.CellPhoneNumber = mySqlDataReader.GetDouble(10);
                    return p;
                }
                else
                    return null;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteProperty(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList propertyArray = new ArrayList();
                Property p = new Property();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "DELETE FROM tblproperty WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();
                    sqlString = "DELETE FROM tblproperty WHERE ID = " + ID.ToString();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateProperty(long ID, Property propertyToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList propertyArray = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "PUT  * FROM tblproperty WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();

                    sqlString = "UPDATE tblProperty SET ComputerMake='" + propertyToSave.ComputerMake +
                        "',ComputerModel='" + propertyToSave.ComputerModel +
                        "',Processor=" + propertyToSave.Processor +
                        ", IssueDate='" + propertyToSave.IssueDate.ToString("yyyy-MM-dd") +
                        "',SerialNumber='" + propertyToSave.SerialNumber +
                        "',Ram='" + propertyToSave.Ram +
                        "',HardDrive=" + propertyToSave.HardDrive +
                        "',CellPhoneMake=" + propertyToSave.CellPhoneMake +
                        "',CellPhoneModel=" + propertyToSave.CellPhoneModel +
                        ",CellPhoneNumber=" + propertyToSave.CellPhoneNumber +
                        "  WHERE ID = " + ID.ToString();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public long SaveProperty(Property propertyToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList propertyArray = new ArrayList();
                string sqlString = "INSERT INTO tblproperty (ComputerMake, ComputerModel, Processor, IssueDate, SerialNumber, Ram, HardDrive, CellPhoneMake, CellPhoneModel, CellPhoneNumber) VALUES ('" + propertyToSave.ComputerMake +
                    "','" + propertyToSave.ComputerModel +
                    "','" + propertyToSave.Processor +
                    "','" + propertyToSave.IssueDate.ToString("yyyy-MM-dd HH:mm:ss") +
                    "','" + propertyToSave.SerialNumber +
                    "','" + propertyToSave.Ram +
                    "','" + propertyToSave.HardDrive +
                    "','" + propertyToSave.CellPhoneMake +
                    "','" + propertyToSave.CellPhoneModel +
                    "','" + propertyToSave.CellPhoneNumber + "')";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}