using Pationts.Entities;
using Pationts.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pationts.Business_Layer
{
    public class CRUD_Operation : BaseRepository

    {

        public static readonly CRUD_Operation Instance = new CRUD_Operation();
        public List<Pationt> GetList(string id)
        {
            var con = GetConnection();
           // Console.WriteLine("Database Connection has been Opened");
            var queries = "SELECT * FROM Pationt";
            var queries2 = "SELECT * FROM Pationt WHERE Id=" +id;
           
            if (id != null) { 
                var cmd = new SqlCommand(queries2, con);
                  var result = GetPationts(cmd, con);
                return result;
            }
            else {
                var cmd = new SqlCommand(queries, con);
                 var result = GetPationts(cmd, con);
                return result;
            }
            

            

            

        }

      
        public List<Doctor>GetList1(string id)
        {
            var con = GetConnection();
            //Console.WriteLine("Database Connection has been Opened");
            var queries = "SELECT * FROM Doctor";

            var queries2 = "SELECT * FROM Doctor WHERE Id= " +id;
            if (id != null)
            {
              
                var cmd = new SqlCommand(queries2, con);
                var result = GetDoctors(cmd, con);

                return result;
            }
            else
            {
                var cmd = new SqlCommand(queries, con);
                var result = GetDoctors(cmd, con);

                return result;
            }

           

        }


        public List<Appointment> GetList2(string Dr_ID, string pat_id, string workingtime)
        {
            var con = GetConnection();
            Console.WriteLine("Database Connection has been Opened");
           // var queries = "SELECT * FROM Appointment";
            var queries2 = "INSERT INTO Appointment(Doctor_Id,Pationt_Id, Appointment_time,confirmed)  VALUES(" + Dr_ID + "," + pat_id + ",\'" + workingtime + "\',0)";

            var cmd = new SqlCommand(queries2, con);

            var result = GetAppointments(cmd, con);

            return result;

        }



        public List<Description> GetList3(string Doc_id, string Pat_id, string description)
        {
            var con = GetConnection();
           // Console.WriteLine("Database Connection has been Opened");
            var queries = "INSERT INTO Description2(Doctor_Id,Pationt_Id, Dec_details)  VALUES(" + Doc_id+","+Pat_id+",\'"+description+"\')";

            var cmd = new SqlCommand(queries, con);

            var result = GetDescriptions(cmd, con);

            return result;

        }

        public List<Description> GetList4(string Pat_id)
        {
            var con = GetConnection();
            // Console.WriteLine("Database Connection has been Opened");
            var queries = "SELECT * FROM Description2 WHERE Pationt_Id = " + Pat_id;
            var queries2 = "SELECT * FROM Description2";
            var cmd = new SqlCommand(queries, con);

            var result = GetDescriptions(cmd, con);

            return result;

        }

        public List<Appointment> GetList5(string Pat_id,string Dr_id)
        {
            var con = GetConnection();
            var queries = "UPDATE Appointment SET confirmed= 1 WHERE Pationt_Id =" + Pat_id + " AND Doctor_Id ="+ Dr_id;
            var cmd = new SqlCommand(queries, con);

            var result = GetAppointments(cmd, con);

            return result;

        }




    }
}
