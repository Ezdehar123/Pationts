using Pationts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pationts.Repository
{
    public class BaseRepository

    {
        private readonly string connectionString;

        protected BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TestHospital"].ConnectionString;
        }

        protected SqlConnection GetConnection()
        {
            var result = new SqlConnection(connectionString);
            return result;
        }




        public List<Pationt> GetPationts(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Pationt>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var pationt = new Pationt();
                    pationt.Id = Convert.ToInt32(reader[0]);
                    pationt.Name = reader[1].ToString();
                    pationt.Age = Convert.ToInt32(reader[2]);
                    pationt.Gender = reader[3].ToString();
                    pationt.Doctor_Id = Convert.ToInt32(reader[4]);
                    list.Add(pationt);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }




        public List<Doctor> GetDoctors(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Doctor>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var doctor = new Doctor();
                    doctor.Id = Convert.ToInt32(reader[0]);
                    doctor.Name = reader[1].ToString();
                    doctor.Specialty = reader[2].ToString();
                    doctor.Working_Hours = reader[3].ToString();
                    list.Add(doctor);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<Appointment> GetAppointments(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Appointment>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var appointment = new Appointment();
                    appointment.Id = Convert.ToInt32(reader[0]);
                    appointment.Doctor_Id = Convert.ToInt32(reader[1]);
                    appointment.Pationt_Id = Convert.ToInt32(reader[2]);
                    appointment.Appointment_time = Convert.ToString(reader[3]);
                    //string bVal =reader[4].ToString();
                    appointment.Confirmed = Convert.ToInt32(reader[4]);

                    
                   // Console.WriteLine(TypeDescriptor.GetConverter(reader[4]).ConvertTo(reader[4], typeof(string)));


                    list.Add(appointment);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }




        public List<Description> GetDescriptions(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Description>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var description= new Description();
                    description.Id = Convert.ToInt32(reader[0]);
                    description.Dec_details = Convert.ToString(reader[1]);
                    description.Doctor_Id = Convert.ToInt32(reader[2]);
                    description.Pationt_Id = Convert.ToInt32(reader[3]);
                   
                    list.Add(description);
                }


                return list;
            }
            finally
            {
                connection.Close();
            }
        }




    }
}
