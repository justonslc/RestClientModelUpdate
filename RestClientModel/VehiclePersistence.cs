using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestClientModel.Models;
using MySql.Data;
using System.Collections;

namespace RestClientModel
{
    public class VehiclePersistence
    {
        Connections connections = new Connections();
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public ArrayList GetVehicle()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                ArrayList vehicleArray = new ArrayList();

                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblvehicle";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Vehicles v = new Vehicles();
                    v.ID = mySqlDataReader.GetInt32(0);
                    v.Make = mySqlDataReader.GetString(1);
                    v.Model = mySqlDataReader.GetString(2);
                    v.Price = mySqlDataReader.GetDouble(3);
                    v.Year = mySqlDataReader.GetDouble(4);
                    v.Used = mySqlDataReader.GetString(5);
                    v.New = mySqlDataReader.GetString(6);
                    v.Color = mySqlDataReader.GetString(7);
                    vehicleArray.Add(v);
                }
                return vehicleArray;
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
        public Vehicles GetVehicle(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                Vehicles v = new Vehicles();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "SELECT * FROM tblvehicle WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    v.ID = mySqlDataReader.GetInt32(0);
                    v.Make = mySqlDataReader.GetString(1);
                    v.Model = mySqlDataReader.GetString(2);
                    v.Price = mySqlDataReader.GetDouble(3);
                    v.Year = mySqlDataReader.GetDouble(4);
                    v.Used = mySqlDataReader.GetString(5);
                    v.New = mySqlDataReader.GetString(6);
                    v.Color = mySqlDataReader.GetString(7);
                    return v;
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
        public bool DeleteVehicle(long ID)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                Person p = new Person();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "DELETE FROM tblvehicle WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();
                    sqlString = "DELETE FROM tblvehicle WHERE ID = " + ID.ToString();
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
        public bool UpdateVehicle(long ID, Vehicles vehicleToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;
                String sqlString = "PUT  * FROM tblvehicle WHERE ID = " + ID.ToString();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    mySqlDataReader.Close();

                    sqlString = "UPDATE tblvehicle SET Make='" + vehicleToSave.Make +
                        "',Model='" + vehicleToSave.Model +
                        "',Year=" + vehicleToSave.Year +
                        ", Price='" + vehicleToSave.Price +
                        "',Used='" + vehicleToSave.Used +
                        "',New='" + vehicleToSave.New +
                        "',Color=" + vehicleToSave.Color +
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
        public long SaveVehicle(Vehicles vehicleToSave)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = connections.myConnectionString;
                conn.Open();
                string sqlString = "INSERT INTO tblvehicle (Make, Model, Year, Price, Used, New, Color) VALUES ('" + vehicleToSave.Make +
                        "','" + vehicleToSave.Model +
                        "','" + vehicleToSave.Year +
                        "','" + vehicleToSave.Price +
                        "','" + vehicleToSave.Used +
                        "','" + vehicleToSave.New +
                        "','" + vehicleToSave.Color + "')";
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

