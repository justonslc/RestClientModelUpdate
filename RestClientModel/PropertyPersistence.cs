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
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public PropertyPersistence()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=Tomorrow111!;database=employeedb";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }
        public ArrayList getProperty()
        {
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
                p.ComputeModel = mySqlDataReader.GetString(2);
                p.Processor = mySqlDataReader.GetString(3);
                p.IssueDate = mySqlDataReader.GetDateTime(4);
                p.SerialNumber = mySqlDataReader.GetString(5);
                p.Ram = mySqlDataReader.GetInt16(6);
                p.HardDrive = mySqlDataReader.GetString(7);
                p.CellPhoneMake = mySqlDataReader.GetString(8);
                p.CellPhoneModel = mySqlDataReader.GetString(9);
                p.CellPhoneNumber = mySqlDataReader.GetDouble(10);
                propertyArray.Add(p);
            }
            return propertyArray;
        }
        public Property getProperty(long ID)
        {
            Property p = new Property();
            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
            String sqlString = "SELECT * FROM tblproperty WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlDataReader = cmd.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                p.ID = mySqlDataReader.GetInt32(0);
                p.ComputerMake = mySqlDataReader.GetString(1);
                p.ComputeModel = mySqlDataReader.GetString(2);
                p.Processor = mySqlDataReader.GetString(3);
                p.IssueDate = mySqlDataReader.GetDateTime(4);
                p.SerialNumber = mySqlDataReader.GetString(5);
                p.Ram = mySqlDataReader.GetInt16(6);
                p.HardDrive = mySqlDataReader.GetString(7);
                p.CellPhoneMake = mySqlDataReader.GetString(8);
                p.CellPhoneModel = mySqlDataReader.GetString(9);
                p.CellPhoneNumber = mySqlDataReader.GetDouble(10);
                return p;
            }
            else
                return null;
        }
        public bool deleteProperty(long ID)
        {
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
        public Property updateProperty(long ID)
        {
            Property p = new Property();
            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
            String sqlString = "PUT * FROM tblproperty WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            mySqlDataReader = cmd.ExecuteReader();
            if (mySqlDataReader.Read())
            {
                p.ID = mySqlDataReader.GetInt32(0);
                p.ComputerMake = mySqlDataReader.GetString(1);
                p.ComputeModel = mySqlDataReader.GetString(2);
                p.Processor = mySqlDataReader.GetString(3);
                p.IssueDate = mySqlDataReader.GetDateTime(4);
                p.SerialNumber = mySqlDataReader.GetString(5);
                p.Ram = mySqlDataReader.GetInt16(6);
                p.HardDrive = mySqlDataReader.GetString(7);
                p.CellPhoneMake = mySqlDataReader.GetString(8);
                p.CellPhoneModel = mySqlDataReader.GetString(9);
                p.CellPhoneNumber = mySqlDataReader.GetDouble(10);
                return p;
            }
            else
                return null;
        }
        public long saveProperty(Property propertyToSave)
        {
            string sqlString = "INSERT INTO tblproperty (ComputerMake, ComputerModel, Processor, IssueDate, SerialNumber, Ram, HardDrive, CellPhoneMake, CellPhoneModel, CellPhoneNumber) VALUES ('" + propertyToSave.ComputerMake +
                "','" + propertyToSave.ComputeModel +
                "','" + propertyToSave.Processor +
                "','" + propertyToSave.IssueDate.ToString("yyyy-MM-dd HH:mm:ss") +
                "','" + propertyToSave.SerialNumber +
                "','" + propertyToSave.Ram +
                "','" + propertyToSave.HardDrive +
                "','" + propertyToSave.CellPhoneMake +
                "','" + propertyToSave.CellPhoneModel +
                "','" + propertyToSave.CellPhoneNumber +"')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}