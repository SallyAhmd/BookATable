using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookATable.BusinessLayer
{
    public class CustBookingTable
    {

        public static int loginName { get; set; }
        public static string BookingName { get; set; }
        public static string Address { get; set; }
        public static string PhoneNumber { get; set; }
        public static DateTime BookingDate { get; set; }
        public static string FromTime { get; set; }
        public static string ToTime { get; set; }

        public static int qty { get; set; }

    }

    public class CustBookingTableDBLayer
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public static int CustBookingRecord()
        {
            try
            {
                using (var command = new SqlCommand("SP_CUSTOMER_BOOKING_TABLE", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    command.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = SessionInfo.LoginName.ToString();
                    command.Parameters.Add("@BookinName", SqlDbType.NVarChar).Value = CustBookingTable.BookingName.ToString();
                    command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = CustBookingTable.Address.ToString();
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = CustBookingTable.PhoneNumber.ToString();
                    command.Parameters.Add("@BookingDate", SqlDbType.DateTime).Value = CustBookingTable.BookingDate;
                    command.Parameters.Add("@FromTime", SqlDbType.NVarChar).Value = CustBookingTable.FromTime.ToString();
                    command.Parameters.Add("@ToTime", SqlDbType.NVarChar).Value = CustBookingTable.ToTime.ToString();
                    command.Parameters.Add("@qty", SqlDbType.Int).Value = CustBookingTable.qty;

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable ViewBookedRecords()
        {
            try
            {

                using (var command = new SqlCommand("SP_VIEW_CUSTOMER_BOOKING_TABLE", con)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    command.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = SessionInfo.LoginName.ToString();

                    con.Open();
                    command.ExecuteNonQuery();
                    var da = new SqlDataAdapter(command);
                    var dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable TableMaster()
        {
            try
            {

                var com = new SqlCommand("SELECT TableId, Quantity FROM TableMaster", con);
                var da = new SqlDataAdapter(com);
                var dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable EmpApprovalData()
        {
            try
            {

                var com = new SqlCommand("SELECT BookId,b.Email, BookingName, Address, a.PhoneNumber, BookingDate, FromTime, ToTime, IsApproved, c.Quantity  FROM CustBookingTable a , AspNetUsers b, TableMaster c WHERE a.ID=b.Id and a.TableId=c.TableId and IsDeleted=0 order by BookingDate DESC", con);
                var da = new SqlDataAdapter(com);
                var dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}