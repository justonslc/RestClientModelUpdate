using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestClientModel.Models;
using MySql.Data;
using System.Collections;
using System.IO;

namespace RestClientModel
{
    

    public class PersonPersistence
    {

        Connections connection = new Connections();
        //private MySql.Data.MySqlClient.MySqlConnection conn;
        public ArrayList GetPersons()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connection.myConnectionString;
                conn.Open();
                ArrayList personArray = new ArrayList();

                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblpersonnel";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Person p = new Person();
                    p.ID = mySqlDataReader.GetInt32(0);
                    p.FirstName = mySqlDataReader.GetString(1);
                    p.LastName = mySqlDataReader.GetString(2);
                    p.PayRate = mySqlDataReader.GetDouble(3);
                    p.StartDate = mySqlDataReader.GetDateTime(4);
                    p.EndDate = mySqlDataReader.GetDateTime(5);
                    p.Address = mySqlDataReader.GetString(6);
                    p.State = mySqlDataReader.GetString(7);
                    p.ZipCode = mySqlDataReader.GetInt64(8);
                    p.PhoneNumber = mySqlDataReader.GetDouble(9);
                    personArray.Add(p);
                }
                return personArray;
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
        public Person GetPerson(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connection.myConnectionString;
                conn.Open();
                Person p = new Person();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    p.ID = mySqlDataReader.GetInt32(0);
                    p.FirstName = mySqlDataReader.GetString(1);
                    p.LastName = mySqlDataReader.GetString(2);
                    p.PayRate = mySqlDataReader.GetDouble(3);
                    p.StartDate = mySqlDataReader.GetDateTime(4);
                    p.EndDate = mySqlDataReader.GetDateTime(5);
                    p.Address = mySqlDataReader.GetString(6);
                    p.State = mySqlDataReader.GetString(7);
                    p.ZipCode = mySqlDataReader.GetInt64(8);
                    p.PhoneNumber = mySqlDataReader.GetDouble(9);
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
        public bool DeletePerson(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connection.myConnectionString;
                conn.Open();
                Person p = new Person();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "DELETE FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();
                    sqlString = "DELETE FROM tblpersonnel WHERE ID = " + ID.ToString();
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

        public bool UpdatePerson(long ID, Person personToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connection.myConnectionString;
                conn.Open();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "PUT  * FROM tblpersonnel WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();

                    sqlString = "UPDATE tblPersonnel SET FirstName='" + personToSave.FirstName +
                        "',LastName='" + personToSave.LastName +
                        "',PayRate=" + personToSave.PayRate +
                        ", StartDate='" + personToSave.StartDate.ToString("yyyy-MM-dd") +
                        "',EndDate='" + personToSave.EndDate.ToString("yyyy-MM-dd") +
                        "',Address='" + personToSave.Address +
                        "',State='" + personToSave.State +
                        "',ZipCode=" + personToSave.ZipCode +
                        ", PhoneNumber=" + personToSave.PhoneNumber +
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
        public long SavePerson(Person personToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connection.myConnectionString;
                conn.Open();
                string sqlString = "INSERT INTO tblPersonnel (FirstName, LastName, PayRate, StartDate, EndDate, Address, State, ZipCode, PhoneNumber) VALUES ('" + personToSave.FirstName +
        "','" + personToSave.LastName +
        "','" + personToSave.PayRate +
        "','" + personToSave.StartDate.ToString("yyyy-MM-dd HH:mm:ss") +
        "','" + personToSave.EndDate.ToString("yyyy-MM-dd HH:mm:ss") +
        "','" + personToSave.Address +
        "','" + personToSave.State +
        "','" + personToSave.ZipCode +
        "','" + personToSave.PhoneNumber + "')";
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
