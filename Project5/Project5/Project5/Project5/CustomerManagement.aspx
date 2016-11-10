<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CustomerManagement.aspx.vb" Inherits="Project5.CustomerManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2> Customer Management Form </h2>
<p> Perform back-end management tasks such as searching, adding, editing, deleting, printing, printing all, and listing all the customers. <br /> </p>
<p> Enter the data and click the desire button to execute the operation. <br /> </p> 


<div style="text-align: left">
<br />
    <table border="0" align="left">
<tr>
<td style="width: 128px; height: 21px">
</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
</td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> <strong>Customer ID</strong></td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> <asp:TextBox ID="txtIDNumber" 
        runat="server" Width="87px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnSearch" runat="server" Text="Search" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> First Name&nbsp; </td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> <asp:TextBox ID="txtFname" runat="server" 
        Width="206px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnAdd" runat="server" Text="Add" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; text-align: right"> Last Name</td>
<td style="width: 18px">
</td>
<td style="width: 342px"> <asp:TextBox ID="txtLname" runat="server" Width="210px"></asp:TextBox></td>
<td style="width: 17px">
</td>
<td style="width: 148px"> <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> SSN</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> <asp:TextBox ID="txtSSN" runat="server" 
        Width="208px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Birthdate</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> <asp:TextBox ID="txtBdate" runat="server" 
        Width="111px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnPrint" runat="server" Text="Print" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Address</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px">
<asp:TextBox ID="txtaddy" runat="server" Width="210px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnPrintAll" runat="server" Text="Print All" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 21px" align="right">
    Phone Number</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
<asp:TextBox ID="txtPhoneNumber" runat="server" Width="210px"></asp:TextBox>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
</tr>
<tr>
<td style="width: 128px; height: 21px" align="right">
    Email</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
<asp:TextBox ID="txtEmail" runat="server" Width="210px"></asp:TextBox>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
    </tr>
    <tr>
<td style="width: 128px; height: 21px" align="right">
    </td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
    </tr>
    
</table>


<br /> 


<br /> 
<br />
 <br />
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br /> 
  <br />
    <br />
     <br />
      <br /> 
      <br /> 
      <br /> 
      <br /> 
      <br /> 
      <br /> <div style="text-align: left">



 <table> <tr> <td style="width: 924px; height: 26px"> <asp:Button ID="btnList" runat="server" Text="List" Width="111px" /></td> </tr> <tr> <td style="width: 924px"> 

     <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False">
         <Columns>
             <asp:BoundField DataField="IDNumber" HeaderText="Customer ID" />
             <asp:BoundField DataField="FirstName" HeaderText="First Name" />
             <asp:BoundField DataField="LastName" HeaderText="Last Name" />
             <asp:BoundField DataField="SSNumber" HeaderText="SSN" />
             <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" />
             <asp:BoundField DataField="Address" HeaderText="Address" />
             <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
             <asp:BoundField DataField="Email" HeaderText="Email" />
         </Columns>
     </asp:GridView>

</td> </tr> </table> </div> <br /> <br /> 
    <br />
    <br /> <br /> 
<br />
<br />
<div style="text-align: left">
<table border="0" align="left">
<tr>
<td style="width: 128px; height: 26px; text-align: right">
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px">
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnSubmit" runat="server" Text=" Submit All Changed & Exit Form " Width="267px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 21px">
</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
</td>
</tr>
</table>
</div>


</div>




</asp:Content>
