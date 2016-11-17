<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Project5._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 32px;
        }
        .style2
        {
            width: 297px;
        }
.TestStyle
  {
  border-bottom: solid #000000;
  border-width: 2px;
  }
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2> &nbsp;Welcome to Small Business Application!
</h2>
<p> <br>This portal will allow you to manage customer records & sell our products to customers. <br /> Please select the desire options links below.</p><div>
<table border="0" style="height: 172px; width: 818px" align="left" >
<tr> <!-- Row 1 -->
<td colspan="3" style="text-align:left">
    <asp:Label ID="lblTitle" style="text-align:left" runat="server" 
        font-size="Medium" CssClass="TestStyle" Text="Navigate to Application Tools"></asp:Label>
    </td>
</tr>
<tr> <!-- Row 2 -->
<td class="style2" >
    <asp:Label ID="lblCustomerManagement" runat="server" 
        Text="Manage Customer Records"></asp:Label>
    :</td>
<td >
    <asp:HyperLink ID="hlCustomerManagement" runat="server" 
        NavigateUrl="~/CustomerManagement.aspx">Customer Management</asp:HyperLink>
    </td>
<td class="style1" ></td>
</tr>
<tr><!-- Row 3 -->
<td class="style2" style="border-style: dashed none none none; border-width: thin" >
    <asp:Label ID="lblRetailManagement" runat="server" 
        Text="Manage Employee Records"></asp:Label>
    :</td>
<td style="border-style: dashed none none none; border-width: thin" >
    <asp:HyperLink ID="hlRetailManagement" runat="server" 
        NavigateUrl="~/EmployeeMngmt.aspx">Employee Management</asp:HyperLink>
    </td>
<td class="style1" style="border-style: none; border-width: thin" ></td>
</tr>
<tr><!-- Row 4 -->
<td class="style2" style="border-style: dashed none none none; border-width: thin" >
    <asp:Label ID="Label1" runat="server" 
        Text="Manage DVD Records"></asp:Label>
    :</td>
<td style="border-style: dashed none none none; border-width: thin" >
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/DVDmngmt.aspx">DVD Management</asp:HyperLink>
    </td>
<td class="style1" style="border-style: none; border-width: thin" ></td>
</tr>
<tr><!-- Row 5 -->
<td class="style2" style="border-style: dashed none none none; border-width: thin" >
    <asp:Label ID="Label2" runat="server" 
        Text="Manage Video Game Records"></asp:Label>
    :</td>
<td style="border-style: dashed none none none; border-width: thin" >
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/VideoGamemngnmt.aspx">Video Game Management</asp:HyperLink>
    </td>
<td class="style1" style="border-style: none; border-width: thin" ></td>
</tr>
</table>
</div>

</asp:Content>