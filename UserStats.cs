using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace projectnewgadi
{
    public class UserStats
    {
        private string username;

        public UserStats(string username)
        {
            this.username = username;
        }
        public UserStats()
        {
            ;
        }
        //Register
        public void PutInfoRegister()
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            string Query = $@"INSERT INTO userstats (username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum) VALUES ('{this.username}','{0}','{0}','{0}','{0}','{0}','{0}','{0}');";
            MySqlCommand command = new MySqlCommand(Query, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        //

        //Change SQL 
        public void AddTrail(string user)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{user}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            int trails = 1;
            if (dr.Read())
            {
                trails += dr.GetInt32(6);
            }
            Query = $@"UPDATE userstats SET trails='{trails}' WHERE username='{user}';";
            command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void AddVpmToSum(int NewVpm,string user)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{user}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();        
            if (dr.Read())
            {
                NewVpm += dr.GetInt32(7);
            }
            Query = $@"UPDATE userstats SET vpm_avrg_sum='{NewVpm}' WHERE username='{user}';";
            command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void AddAccuracyToSum(double NewAcc, string user)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{user}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                NewAcc += dr.GetDouble(8);
            }
            Query = $@"UPDATE userstats SET accuracy_avrg_sum='{NewAcc}' WHERE username='{user}';";
            command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void AddPoints(double NewPoints,string user)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{user}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                NewPoints += dr.GetDouble(5);
            }
            Query = $@"UPDATE userstats SET points='{NewPoints}' WHERE username='{user}';";
            command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void ChangeVPM_AVG(string user)
        {

            //VPM_AVG = VPM_SUM / TRAILS
        }
        public void ChangeACC_AVG(string user)
        {
            //ACC_AVG = ACC_SUM / TRAILS
        }
        public void ChangeUserPassword(string user,string newpassword)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"UPDATE users SET password='{newpassword}' WHERE username='{user}';";
            MySqlCommand command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public bool AddTextToData(string user,string text)
        {
            if (TextAndUserInData(user, text) == true)
            {
                return false;
            }
            MySqlConnection conn = new MySqlConnection(Connection.user);
            string Query = $@"INSERT INTO texts (user,textstring) VALUES ('{user}','{text}');";
            MySqlCommand command = new MySqlCommand(Query, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public bool TextAndUserInData(string user,string text)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,user,textstring from texts where user='{user}' and textstring='{text}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public bool LikeAtext(string text,string usertext,string user)//שמים סייסיה עם הטקסט והשם ואז בסוף מוחקים
        {
            IfTheTextInReviewAlready(text, usertext);
            string allvotedusers = "";
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,user,text,charnum,likes,voted from review where user='{usertext}' and text='{text}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                allvotedusers = dr.GetString(5);
            }

            if (IfUserVoted(user, allvotedusers) == true)//seek if user already have reviewed this post
            {
                return false;
            }
            AddLikeToReviewAndUserToVoted(usertext,text,user);//Add like and user to review
            return true;
        }
        public bool IfTheTextInReviewAlready(string text,string usertext)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,user,text,charnum,likes,voted from review where user='{usertext}' and text='{text}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return true;
            }
            AddAtextToReview(usertext, text);
            conn.Close();
            return false;
        }

        public void AddAtextToReview(string usertext,string text)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            string Query = $@"INSERT INTO review (user,text,charnum,likes,voted) VALUES ('{usertext}','{text}','{text.Length}','{0}','{""}');";//maybe problem with last
            MySqlCommand command = new MySqlCommand(Query, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void AddLikeToReviewAndUserToVoted(string usertext,string text,string uservoted)
        {
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,user,text,charnum,likes,voted from review where user='{usertext}' and text='{text}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            int likes = 1;
            string voted = "";
            if (dr.Read())
            {
                likes += dr.GetInt32(4);
                voted = dr.GetString(5) + uservoted + ";";
            }
            conn.Close();
            conn.Open();
            Query = $@"UPDATE review SET likes='{likes}',voted='{voted}' WHERE user='{usertext}' and text='{text}';";
            command = new MySqlCommand(Query, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        //


        //Return by name
        public double ReturnUserPoints(string UserName)
        {
            double points = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                points = dr.GetDouble(5);
            }
            conn.Close();
            return points;
        }
        public double ReturnUserTrails(string UserName)
        {
            int trails = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                trails = dr.GetInt32(6);
            }
            conn.Close();
            return trails;
        }
        public double ReturnUserVPM_AVG(string UserName)
        {
            double VPM = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                VPM = dr.GetInt32(2);
            }
            conn.Close();
            return VPM;
        }
        public double ReturnUserACC_AVG(string UserName)
        {
            double ACC = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                ACC = dr.GetDouble(3);
            }
            conn.Close();
            return ACC;
        }
        public double ReturnUserTIME(string UserName)
        {
            double TIME = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                TIME = dr.GetInt32(4);
            }
            conn.Close();
            return TIME;
        }
        public double ReturnUserVPM_SUM(string UserName)
        {
            double VPM = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                VPM = dr.GetInt32(7);
            }
            conn.Close();
            return VPM;
        }
        public double ReturnUserACC_SUM(string UserName)
        {
            double ACC = 0;
            MySqlConnection conn = new MySqlConnection(Connection.user);
            conn.Open();
            string Query = $@"select id,username,vpm_avrg,accuracy_avrg,time,points,trails,vpm_avrg_sum,accuracy_avrg_sum from userstats where username='{UserName}'";
            MySqlCommand command = new MySqlCommand(Query, conn);
            MySqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                ACC = dr.GetDouble(8);
            }
            conn.Close();
            return ACC;
        }

        public bool IfUserVoted(string username,string allvotedusers)
        {
            while (allvotedusers != "")
            {
                string user1 = allvotedusers.Substring(0, allvotedusers.IndexOf(';'));
                allvotedusers = allvotedusers.Remove(0, allvotedusers.IndexOf(';') + 1);
                if (username == user1) 
                {
                    return true;
                }
            }
            return false;
        }
        //



        //Random things(MATH)
        public double PointsCalc(double vpm, double accuracy)
        {
            double points = 0.1 * vpm + 0.2 * accuracy;
            return points;
        }
        //

       
    }

    
}