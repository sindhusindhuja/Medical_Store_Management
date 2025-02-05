﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using DTO;
using System.Data;

namespace DAL
{
    class MedicalDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;

        public MedicalDAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();
        }
        public int checkLogin(MedicalDTO newObj)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["Medical"].ConnectionString;

                sqlCmdObj.CommandText = @"UserMst_Select_for_login";

                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Connection = sqlConObj;

                
                sqlCmdObj.Parameters.AddWithValue("@name", newObj.UserName);
                sqlCmdObj.Parameters.AddWithValue("@pass", newObj.UserPassword);

                //Return
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                sqlCmdObj.Parameters.Add(prmReturn);

                sqlConObj.Open();

                //non execute query
                sqlCmdObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public  String Client(MedicalDTO newObj1)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["Medical"].ConnectionString;

                sqlCmdObj.CommandText = @"dbo.Client_Pro1";

                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Connection = sqlConObj;


                sqlCmdObj.Parameters.AddWithValue("@CU_Id", newObj1.CU_Id);
                sqlCmdObj.Parameters.AddWithValue("@CU_Name",newObj1.CU_Name);
                sqlCmdObj.Parameters.AddWithValue("@CU_Surname", newObj1.CU_Surname);
                sqlCmdObj.Parameters.AddWithValue("@CU_Mobile_No", newObj1.CU_Mobile_No);
                sqlCmdObj.Parameters.AddWithValue("@CU_Address", newObj1.CU_Address);
                sqlCmdObj.Parameters.AddWithValue("@CU_City", newObj1.CU_City);
                //sqlCmdObj.Parameters.AddWithValue("@Query", 1);

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                sqlCmdObj.Parameters.Add(prmReturn);

                sqlConObj.Open();
                
                //non execute query
                sqlCmdObj.ExecuteNonQuery();
                return "";

            }
            catch (Exception e)
            {
                
                throw e;
                
            }
        }
    }
}
