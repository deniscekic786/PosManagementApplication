<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DVDmngmt.aspx.vb" Inherits="Project5.DVDmngmt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<h2> DVD Management Form </h2>
<p> Perform back-end management tasks such as searching, adding, editing, deleting, printing, printing all, and listing all the 
    DVD&#39;s. <br /> </p>
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
<td style="width: 128px; height: 26px; text-align: right"> <strong>DVD ID</strong></td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> <asp:TextBox ID="txtIDNumber" 
        runat="server" Width="87px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnSearch" runat="server" Text="Search" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Title&nbsp; </td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> 
    <asp:TextBox ID="txtTitle" runat="server" 
        Width="206px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnAdd" runat="server" Text="Add" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; text-align: right"> Description</td>
<td style="width: 18px">
</td>
<td style="width: 342px"> <asp:TextBox ID="txtDesc" runat="server" Width="210px"></asp:TextBox></td>
<td style="width: 17px">
</td>
<td style="width: 148px"> <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Rating</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> 
    <asp:DropDownList ID="dlEnumRating" runat="server">
        <asp:ListItem>G</asp:ListItem>
        <asp:ListItem>PG</asp:ListItem>
        <asp:ListItem>PG_13</asp:ListItem>
        <asp:ListItem>NC_17</asp:ListItem>
        <asp:ListItem>R</asp:ListItem>
        <asp:ListItem>None</asp:ListItem>
    </asp:DropDownList>
    </td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="111px" /></td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Sale Price</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px"> 
    <asp:TextBox ID="txtSale" runat="server" 
        Width="206px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> &nbsp;</td>
</tr>
<tr>
<td style="width: 128px; height: 26px; text-align: right"> Rental Rate</td>
<td style="width: 18px; height: 26px">
</td>
<td style="width: 342px; height: 26px">
<asp:TextBox ID="txtRent" runat="server" Width="210px"></asp:TextBox></td>
<td style="width: 17px; height: 26px">
</td>
<td style="width: 148px; height: 26px"> &nbsp;</td>
</tr>
<tr>
<td style="width: 128px; height: 21px" align="right">
    Late Fee</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
<asp:TextBox ID="txtLatefee" runat="server" Width="210px"></asp:TextBox>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
</tr>
<tr>
<td style="width: 128px; height: 21px" align="right">
    Category</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
    <asp:DropDownList ID="dlEnumCategory" runat="server">
        <asp:ListItem>Action_Adventure</asp:ListItem>
        <asp:ListItem>Drama</asp:ListItem>
        <asp:ListItem>Family_Kids</asp:ListItem>
        <asp:ListItem>Horror</asp:ListItem>
        <asp:ListItem>Sci_Fi_Fantasy</asp:ListItem>
        <asp:ListItem>Music</asp:ListItem>
        <asp:ListItem>Sports</asp:ListItem>
        <asp:ListItem>Romance</asp:ListItem>
        <asp:ListItem>Comedy</asp:ListItem>
        <asp:ListItem>Western</asp:ListItem>
        <asp:ListItem>None</asp:ListItem>
    </asp:DropDownList>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
    </tr>
    <tr>
<td style="width: 128px; height: 21px" align="right">
    Format</td>
<td style="width: 18px; height: 21px">
</td>
<td style="width: 342px; height: 21px">
    <asp:DropDownList ID="dlEnumFormat" runat="server">
        <asp:ListItem>DVD</asp:ListItem>
        <asp:ListItem>HD_DVD</asp:ListItem>
        <asp:ListItem>BLU_RAY</asp:ListItem>
        <asp:ListItem>DISC</asp:ListItem>
        <asp:ListItem Value="None">None</asp:ListItem>
    </asp:DropDownList>
</td>
<td style="width: 17px; height: 21px">
</td>
<td style="width: 148px; height: 21px">
    &nbsp;</td>
</tr>
<tr>
    <td style="width: 128px; height: 21px" align="right">
    Availability:</td>
<td style="width: 342px; height: 21px">
<asp:RadioButton ID="radYes" runat="server" Text="Yes" Checked="True"
GroupName="Available" />
<br />
<br />
<asp:RadioButton ID="radNo" runat="server" Text="No"
GroupName="Gender" />
<br />
</td>
<td style="width: 342px; height: 21px">
    &nbsp;</td>
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
             <asp:BoundField DataField="ID_Number" HeaderText="DVD ID" />
             <asp:BoundField DataField="Title" HeaderText="Title" />
             <asp:BoundField DataField="Description" HeaderText="Description" />
             <asp:BoundField DataField="EnumRating" HeaderText="Rating" />
             <asp:BoundField DataField="Sale_Price" HeaderText="Sale Price" />
             <asp:BoundField DataField="Rental_Rate" HeaderText="Rental Price" />
             <asp:BoundField DataField="Late_Fee" HeaderText="Late Fee" />
             <asp:BoundField DataField="Enum_Movie_Category" HeaderText="Category" />
             <asp:BoundField DataField="DVD_Formats" HeaderText="Format" />
             <asp:BoundField DataField="Availability" HeaderText="Availability" />
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























</asp:Content>
