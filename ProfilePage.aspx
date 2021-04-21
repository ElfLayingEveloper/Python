<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="projectnewgadi.ProfilePage" %>

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
        .Back {
            background-image:url("user-profile-bg.jpg");
                        background-size: cover;
        }
    </style>
</head>
<body class="Back">
    <form id="form1" runat="server">
        <div>

              <table id="InfoTable">
            <tr>
                    <td><asp:Button ID="MainPage" runat="server" Height="41px" Width="204px" Text="Main Page" OnClick="MainPage_Click" /></td>
                    <td><asp:Button ID="TypeRacer" runat="server" Height="41px" Width="204px" Text="Type Racer Game" OnClick="TypeRacer_Click" /></td>
                    <td><asp:Button ID="TOP" runat="server" Height="41px" Width="204px" Text="Top 10 players" OnClick="TOP_Click" /></td>
                    <td><asp:Button ID="TextReview" runat="server" Height="41px" Width="204px" Text="TextReview" OnClick="TextReview_Click" /></td>
                    <td><asp:Button ID="Logout" runat="server" Height="41px" Width="204px" Text="Logout" OnClick="Logout_Click" /></td>
            </tr>
                 </table>
            <br />

            <br />

            <br />
            <center>
            <h1>User profile:</h1>
            <asp:Panel ID="UserStats" runat="server">
               <asp:TextBox ID="Username" runat="server" ReadOnly="true" Width="300px">Username:</asp:TextBox>
                <br />
                <asp:TextBox ID="Password" runat="server" ReadOnly="true" Width="300px">Password:</asp:TextBox>
                <br />
                <asp:TextBox ID="TimePlayed" runat="server" ReadOnly="true" Width="300px">Time played:</asp:TextBox>
                <br />
                <asp:TextBox ID="WPM" runat="server" ReadOnly="true" Width="300px">WPM:</asp:TextBox>
                <br />
                <asp:TextBox ID="Acurracy" runat="server" ReadOnly="true" Width="300px">Acuraccy:</asp:TextBox>
                <br />
                <asp:TextBox ID="Trails" runat="server" ReadOnly="true" Width="300px">Trails:</asp:TextBox>
                <br />
                <asp:TextBox ID="Points" runat="server" ReadOnly="true" Width="300px">Points:</asp:TextBox>
                <br />
                <p>Change password:</p>
                <asp:TextBox ID="PasswordChange" runat="server"  Width="300px" autocomplete="off"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="ChangePass" runat="server" Height="41px" Width="204px" Text="Confirm new password" OnClick="PasswordChange_Click" />
            </asp:Panel>
                </center>
            
        </div>
    </form>
</body>
</html>
