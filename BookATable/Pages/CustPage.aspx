<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustPage.aspx.cs" Inherits="BookATable.Pages.CustPage" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid" style="padding: 50px">
        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                    <a href="#" class="btn btn-default btn-custom bArea">
                        <span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
                        <br />
                        <span class="btntext glyphicon-class">Table Booking Area</span>
                    </a>

                </div>
                <div class="col-md-6">
                    <a href="#" class="btn btn-default btn-custom bStstus">
                        <span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
                        <br />
                        <span class="btntext glyphicon-class">Table Booking Status</span>
                    </a>

                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid bAreaView" style="padding: 50px">
        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                    <h2 style="align-content: center">Table Booking Area</h2>
                </div>
            </div>
        </div>
        <form>
            <div class="form-group">
                <label>Booking Name</label>
                <input type="text" class="form-control" id="bookName" placeholder="Enter Name">
            </div>
            <div class="form-group">
                <label>Address</label>
                <textarea class="form-control" id="address" placeholder="Address"></textarea>
            </div>
            <div class="form-group">
                <label>Phone Number</label>
                <input type="text" class="form-control" id="number" placeholder="Phone Number">
            </div>
            <div class="form-group">
                <label>Booking Date</label>
                <input type="text" id="datepicker">
            </div>
            <div class="form-group">
                <label>From Time</label>
                <asp:DropDownList runat="server" ID="fTime">
                    <asp:ListItem Text="06:00 PM" />
                    <asp:ListItem Text="07:00 PM" />
                    <asp:ListItem Text="08:00 PM" />
                    <asp:ListItem Text="09:00 PM" />
                    <asp:ListItem Text="10:00 PM" />
                    <asp:ListItem Text="11:00 PM" />
                </asp:DropDownList>

                <label>To Time</label>
                <asp:DropDownList runat="server" ID="tTime">
                    <asp:ListItem Text="07:00 PM" />
                    <asp:ListItem Text="08:00 PM" />
                    <asp:ListItem Text="09:00 PM" />
                    <asp:ListItem Text="10:00 PM" />
                    <asp:ListItem Text="11:00 PM" />
                    <asp:ListItem Text="12:00 PM" />
                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label>No of Persons</label>
                <asp:DropDownList runat="server" ID="ddlTable" CssClass="dropdown-toggle">
                   
                </asp:DropDownList>


            </div>
            <input type="button" class="btn btn-primary saveBooking" value="Book a Table" />
        </form>

    </div>
    <div class="container-fluid bStatusView">
        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                    <h2 style="align-content: center">Table Booking Status</h2>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-8">
                    <%-- <div class="card" style="width: 18rem;">
                        <div class="card-body">
                            <h5 class="card-title">Card title</h5>
                            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>--%>
                    <asp:Repeater ID="RepterDetails" OnItemDataBound="RepterDetails_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table style="border: 1px solid #0000FF; width: 500px" cellpadding="0">
                                <tr style="background-color: #FF6600; color: #000000; font-size: large; font-weight: bold;">
                                    <td colspan="2">
                                        <b>Booking Record</b>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="background-color: #EBEFF0">
                                <td>
                                    <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px">
                                        <tr>
                                            <td>Table Booked in the Name of:  
                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("BookingName") %>' Font-Bold="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComment" runat="server" Text='<%#Eval("Address") %>' />
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
                                        <tr>
                                            <td>Phone Number:
                                                <asp:Label ID="lblUser" runat="server" Font-Bold="true" Text='<%#Eval("PhoneNumber") %>' /></td>
                                            <td>Status:<asp:Label ID="lblStatus" runat="server" Font-Bold="true" /></td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
                                        <tr>
                                            <td>Booking Date:<asp:Label ID="lblDate" runat="server" Font-Bold="true" Text='<%#Eval("BookingDate") %>' /></td>
                                             <td>Timmings<asp:Label ID="lblTimming" runat="server" Font-Bold="true"/></td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>  
                        </FooterTemplate>
                    </asp:Repeater>

                </div>
            </div>

        </div>

    </div>
</asp:Content>
