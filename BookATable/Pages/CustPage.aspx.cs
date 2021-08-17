using BookATable.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookATable.Pages
{
    public partial class CustPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dtTable = CustBookingTableDBLayer.TableMaster();

                ddlTable.DataSource = dtTable;
                ddlTable.DataTextField = "Quantity";
                ddlTable.DataValueField = "TableId";
                ddlTable.DataBind();

                RepeterData();
            }
        }



        [WebMethod]
        public static string SaveBooking(string BookinName, string Add, string Phone, DateTime bookingDate, string From, string To, string qty)
        {
            

            try
            {
            
                CustBookingTable.BookingName = BookinName.ToString();
                CustBookingTable.Address = Add.ToString();
                CustBookingTable.PhoneNumber = Phone.ToString();
                CustBookingTable.BookingDate = bookingDate;
                CustBookingTable.FromTime = From.ToString();
                CustBookingTable.ToTime = To.ToString();
                CustBookingTable.qty = Convert.ToInt32(qty);


                int result = CustBookingTableDBLayer.CustBookingRecord();

                return result.ToString();
            }
            finally
            {
 

            }
        }

        public void RepeterData()
        {
            DataTable dt = CustBookingTableDBLayer.ViewBookedRecords();

            RepterDetails.DataSource = dt;
            RepterDetails.DataBind();

        }

        protected void RepterDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Item item = (item)e.Item.DataItem; 

                DataRowView drv = (DataRowView)e.Item.DataItem;

                Label BookingDate = e.Item.FindControl("lblDate") as Label;

                Label approvalStatus = e.Item.FindControl("lblStatus") as Label;

                Label lblTimmings = e.Item.FindControl("lblTimming") as Label;

                DateTime a = Convert.ToDateTime(drv.Row["BookingDate"]);

                if (drv.Row["IsApproved"].ToString()=="0")
                {
                    approvalStatus.Text = "Booking Pending";
                }
                else if (drv.Row["IsApproved"].ToString() == "1")
                {
                    approvalStatus.Text = "Table Booked";
                }


                lblTimmings.Text = drv.Row["FromTime"].ToString() + '-' + drv.Row["ToTime"].ToString();

                BookingDate.Text= a.ToString("dd/MM/yyyy");

            }
        }
    }
}