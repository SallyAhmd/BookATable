using BookATable.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookATable.Pages
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmpRepeterData();
            }
        }

        public void EmpRepeterData()
        {
            DataTable ApprovalData = CustBookingTableDBLayer.EmpApprovalData();

            Repeater1.DataSource = ApprovalData;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Item item = (item)e.Item.DataItem; 

                DataRowView drv = (DataRowView)e.Item.DataItem;

                Label lblUser = e.Item.FindControl("lblUser") as Label;

                Label lblBD = e.Item.FindControl("lblBD") as Label;

                Label lblStatus = e.Item.FindControl("lblStatus") as Label;

                Label lblqty = e.Item.FindControl("lblqty") as Label;

                DateTime a = Convert.ToDateTime(drv.Row["BookingDate"]);

                lblUser.Attributes["BookID"] = drv.Row["BookId"].ToString();

                if (drv.Row["IsApproved"].ToString() == "0")
                {
                    lblStatus.Text = "Booking Pending";
                }
                else if (drv.Row["IsApproved"].ToString() == "1")
                {
                    lblStatus.Text = "Table Booked";
                }

                lblqty.Text = "No of Persons " + drv.Row["Quantity"].ToString();

                lblBD.Text = a.ToString("dd/MM/yyyy") + "(" + drv.Row["FromTime"].ToString() + '-' + drv.Row["ToTime"].ToString() + ")";

            }
        }
    }
}