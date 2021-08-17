<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="BookATable.Pages.EmployeePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="form-group">
            <div class="row">
                <h2>Booking Approval Records</h2>
                <div class="col-md-12">
                    <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered">
                                <tr>
                                    <td><b>Registered User</b></td>
                                    <td><b>Booking Name</b></td>
                                    <td><b>Address</b></td>
                                    <td><b>Phone Number</b></td>
                                    <td><b>Booking Date</b></td>
                                    <td><b>Status</b></td>
                                    <td><b>Number of Persons</b></td>
                                    <td><b>Approval</b></td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUser" runat="server" Text='<%#Eval("Email") %> ' />
                                </td>
                                <td>
                                    <asp:Label ID="lblBName" runat="server" Text='<%#Eval("BookingName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblAdd" runat="server" Text='<%#Eval("Address") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblPN" runat="server" Text='<%#Eval("PhoneNumber") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblBD" runat="server" Text='<%#Eval("BookingDate") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("IsApproved") %>' />
                                </td>
                                <td style="padding: 10px;">
                                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("Quantity") %>' />
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="padding: 10px;">
                                                <input type="button" value="Approve" class="btn btn-primary" />

                                            </td>
                                            <td style="padding: 10px;">
                                                <input type="button" value="Decline" class="btn btn-primary" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
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
