using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace leafletDemo.Models
{
    public class EstacionsDataAccessLayer
    {
        string connectionString = "server=hermes;port=3306;database=estacions;uid=estacio;password=estacio";
        //To View all Estacionss details              
        public IEnumerable<Estacions> GetAllEstacions()
        {
            List<Estacions> lstEstacions = new List<Estacions>();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("NewProc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Estacions estacio = new Estacions();
                    estacio.dateTime = Convert.ToInt32(rdr["dateTime"]);
                    estacio.usUnits = Convert.ToInt32(rdr["usUnits"]);
                    estacio.arcInt = Convert.ToInt32(rdr["arcInt"]);
                    lstEstacions.Add(estacio);
                }
                con.Close();
            }
            return lstEstacions;
        }


        // //To Add new Estacions record              
        // public vodateTime AddEstacions(Estacions Estacions)            
        // {                
        //     using (SqlConnection con = new SqlConnection(connectionString))                
        //     {                    
        //         SqlCommand cmd = new SqlCommand("spAddEstacions", con);                    
        //         cmd.CommandType = CommandType.StoredProcedure;                        
        //         cmd.Parameters.AddWithValue("@usUnits", Estacions.usUnits);                    
        //         cmd.Parameters.AddWithValue("@arcInt", Estacions.arcInt);                    
        //         cmd.Parameters.AddWithValue("@barometer", Estacions.barometer);                    
        //         cmd.Parameters.AddWithValue("@pressure", Estacions.pressure);                        
        //         con.Open();                    
        //         cmd.ExecuteNonQuery();                    
        //         con.Close();                
        //     }            
        // }                


        //To Update the records of a particluar Estacions            
        // public vodateTime UpdateEstacions(Estacions Estacions)            
        // {                
        //     using (SqlConnection con = new SqlConnection(connectionString))                
        //     {                    
        //         SqlCommand cmd = new SqlCommand("spUpdateEstacions", con);                    
        //         cmd.CommandType = CommandType.StoredProcedure;                        
        //         cmd.Parameters.AddWithValue("@EmpdateTime", Estacions.dateTime);                    
        //         cmd.Parameters.AddWithValue("@usUnits", Estacions.usUnits);                    
        //         cmd.Parameters.AddWithValue("@arcInt", Estacions.arcInt);                    
        //         cmd.Parameters.AddWithValue("@barometer", Estacions.barometer);                    
        //         cmd.Parameters.AddWithValue("@pressure", Estacions.pressure);                        
        //         con.Open();                    
        //         cmd.ExecuteNonQuery();                    
        //         con.Close();                
        //         }            
        // }                


        //Get the details of a particular Estacions            
        public Estacions GetEstacionsData(int? dateTime)
        {
            Estacions estacio = new Estacions();
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblEstacions WHERE EstacionsdateTime= " + dateTime;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    estacio.dateTime = Convert.ToInt32(rdr["dateTime"]);
                    estacio.usUnits = Convert.ToInt32(rdr["usUnits"]);
                    estacio.arcInt = Convert.ToInt32(rdr["arcInt"]);
                    estacio.barometer = Convert.ToInt32(rdr["barometer"]);

                }
            }
            return estacio;
        }

        //To Delete the record on a particular Estacions            
        // public vodateTime DeleteEstacions(int? dateTime)            
        // {                    
        //     using (SqlConnection con = new SqlConnection(connectionString))                
        //     {                    
        //         SqlCommand cmd = new SqlCommand("spDeleteEstacions", con);                    
        //         cmd.CommandType = CommandType.StoredProcedure;                        
        //         cmd.Parameters.AddWithValue("@EmpdateTime", dateTime);                        
        //         con.Open();                    
        //         cmd.ExecuteNonQuery();                    
        //         con.Close();               
        //             }            
        // }        
    }
}
