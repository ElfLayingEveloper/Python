<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="projectnewgadi.HomePage" %>

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
        #Ranks{
          border: 1px solid black;
        }
        .Back{
           background-image:url("");  
           background-size: cover;
           background-repeat:no-repeat;
        }
    </style>
</head>
<body class="Back">
    <form id="form1" runat="server">
        <div>
            <center>
             <table id="InfoTable">
            <tr>
                    <td><asp:Button ID="TypeRacer" runat="server" Height="41px" Width="204px" Text="Type Racer Game" OnClick="TypeRacer_Click" /></td>
                    <td><asp:Button ID="UserStats" runat="server" Height="41px" Width="204px" Text="Profile/Change password" OnClick="UserStats_Click" /></td>
                    <td><asp:Button ID="TOP" runat="server" Height="41px" Width="204px" Text="Top 10 players" OnClick="TOP_Click" /></td>
                    <td><asp:Button ID="TextReview" runat="server" Height="41px" Width="204px" Text="TextReview" OnClick="TextReview_Click" /></td>
                    <td><asp:Button ID="Logout" runat="server" Height="41px" Width="204px" Text="Logout" OnClick="Logout_Click" /></td>
            </tr>
                 </table>
                </center>
            <br />
            <br />
            <center>
                  <h1>Explanation of Type racer</h1>
            </center>
                <p>TypeRacer is a multiplayer online browser-based typing game. In TypeRacer,
                    players complete typing tests of various texts as fast as possible,
                    competing against themselves or with other users online.
                    <br /> Terms:<br /> WPM - Words Per Minute:is a measure of words processed in a minute,
                    often used as a measurement of the speed of typing, reading or Morse code sending and receiving.
          
                    <br /> Accuracy: a player's accuracy is the percentage of the characters entered correctly in the text.
                    A player's points is an alternate way of measuring how well a person did in a race. The better a player performs,
                    the more points that player gets.<br /> Points: your score, the more and better you play you will receive them more.

                </p>
<h4>Ranks as WPM:</h4>
<table id="Ranks">     
<tr >
<th>Rank
</th>
<th>WPM
</th></tr>
<tr>
<td>Beginner
</td>
<td>0 – 24
</td></tr>
<tr>
<td>Intermediate
</td>
<td>25 – 30
</td></tr>
<tr>
<td>Advanced
</td>
<td>31 – 41
</td></tr>
<tr>
<td>Pro
</td>
<td>42 – 54
</td></tr>
<tr>
<td>Typemaster
</td>
<td>55 – 79
</td></tr>
<tr>
<td>Megaracer
</td>
<td>80 +
</td></tr>
           </table>
            <CENTER>
                <asp:Button ID="launch" runat="server" Text="Play Type Racer (join game)" Height="56px" Width="245px" OnClick="launch_Click" />
            </CENTER>

           
        </div>
    </form>
</body>
</html>
