<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopPage.aspx.cs" Inherits="projectnewgadi.TopPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Back{
           background-image:url("top-10-back.jpg");  
           background-size: cover;
        }
        .FakeTable{
            background-color:white;
        }
        #InfoTable {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
    </style>
</head>
<body class="Back">
    <form id="form1" runat="server">
        <div>
            <center>
             <table id="InfoTable">
            <tr>
                    <td><asp:Button ID="MainPage" runat="server" Height="41px" Width="204px" Text="Main Page" OnClick="MainPage_Click" /></td>
                    <td><asp:Button ID="TypeRacer" runat="server" Height="41px" Width="204px" Text="Type Racer Game" OnClick="TypeRacer_Click" /></td>
                    <td><asp:Button ID="UserStats" runat="server" Height="41px" Width="204px" Text="Profile/Change password" OnClick="UserStats_Click" /></td>
                    <td><asp:Button ID="TextReview" runat="server" Height="41px" Width="204px" Text="TextReview" OnClick="TextReview_Click" /></td>
                    <td><asp:Button ID="Logout" runat="server" Height="41px" Width="204px" Text="Logout" OnClick="Logout_Click" /></td>
            </tr>
                 </table>
            <br />
            <br />
            <br />
            <h1>Top 10</h1>
            <br />
            <asp:GridView ID="GridView1" CssClass="FakeTable" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="260px" Width="498px" >
                <Columns>
                    <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                    <asp:BoundField DataField="points" HeaderText="Points" SortExpression="points" />
                    <asp:BoundField DataField="vpm_avrg" HeaderText="WPM" SortExpression="vpm_avrg" />
                    <asp:BoundField DataField="accuracy_avrg" HeaderText="Accuracy" SortExpression="accuracy_avrg" />
                </Columns>
             </asp:GridView>
                </center>
            

             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:work#1ConnectionString %>" ProviderName="<%$ ConnectionStrings:work#1ConnectionString.ProviderName %>" SelectCommand="SELECT username,points,vpm_avrg,accuracy_avrg from userstats order by points Desc LIMIT 10;"></asp:SqlDataSource>
            

        </div>
    </form>
</body>
</html>
