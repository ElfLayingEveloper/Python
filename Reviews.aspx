<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="projectnewgadi.Reviews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
                #InfoTable {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
                        .FakeTable{
            background-color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
             <table id="InfoTable">
            <tr>
                    <td><asp:Button ID="MainPage" runat="server" Height="41px" Width="204px" Text="Main Page" OnClick="MainPage_Click" /> </td>
                    <td><asp:Button ID="TypeRacer" runat="server" Height="41px" Width="204px" Text="Type Racer Game" OnClick="TypeRacer_Click" /></td>
                    <td><asp:Button ID="UserStats" runat="server" Height="41px" Width="204px" Text="Profile/Change password" OnClick="UserStats_Click" /></td>
                    <td><asp:Button ID="TOP" runat="server" Height="41px" Width="204px" Text="Top 10 players" OnClick="TOP_Click" /></td>
                    <td><asp:Button ID="Logout" runat="server" Height="41px" Width="204px" Text="Logout" OnClick="Logout_Click" /></td>
            </tr>
                 </table>
                </center>
            <center>
                <h1> Add a text</h1>
                <p>The text most be between 50-200 chars!(signs/digits)</p>
                <asp:TextBox ID="Text" runat="server" Height="32px" Width="1339px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="TextBot" runat="server" Height="41px" Width="204px" Text="Check the text" OnClick="TextCheck_Click" />
                <br />
                <asp:Label ID="ResultText" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <br />
               <asp:Button ID="Button1" runat="server" Height="41px" Width="204px" Text="Like me now" OnClick="loles_Click" />
                <h1>Most liked texts</h1>
                <br />
                <br />
                <asp:GridView ID="GridView1" CssClass="FakeTable" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="260px" Width="647px" >
                    <Columns>
                        <asp:BoundField DataField="user" HeaderText="Added by" SortExpression="user" />
                        <asp:BoundField DataField="likes" HeaderText="Likes" SortExpression="likes" />
                        <asp:BoundField DataField="charnum" HeaderText="Number of digits" SortExpression="charnum" />
                        <asp:BoundField DataField="text" HeaderText="Text" SortExpression="text" />
                    </Columns>
                 </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:work#1ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:work#1ConnectionString2.ProviderName %>" SelectCommand="SELECT user,text,charnum,likes from review order by likes Desc LIMIT 10;"></asp:SqlDataSource>
            </center>

        </div>
    </form>
</body>
</html>
