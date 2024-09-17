using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LMS_v1.MiddleWares
{
    public class DataSeeder
    {
        private SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString);
        public void Seed()
        {
            AddUser("MgMg", "mag12", "psw123", "mgmg@gmail.com");
            AddUser("HlaHla", "ma12", "psw123", "hlahla@gmail.com");
            AddUser("MaMa", "hla12", "psw123", "mama@gmail.com");
            AddUser("HsuHsu", "hsu12", "psw123", "hsu@gmail.com");
            AddUser("SeinSein", "sein12", "psw123", "seinsein@gmail.com");
            AddUser("HtooHtoo", "htoo12", "psw123", "htoohtoo@gmail.com");
            AddUser("AungAung", "aung12", "psw123", "aungaung@gmail.com");
            AddUser("LinLin", "lin12", "psw123", "linlin@gmail.com");
            AddUser("HlaHla", "hla12", "psw123", "hlahla@gmail.com");
            AddUser("AyeAye", "aye12", "psw123", "ayeaye@gmail.com");
            AddUser("JueJue", "jue12", "psw123", "juejue@gmail.com");
            AddUser("Thandar", "thandar12", "psw123", "thandar@gmail.com");
            AddUser("KhineKhine", "khine12", "psw123", "khinekhine@gmail.com");
            AddUser("HninHnin", "hnin12", "psw123", "hnin@gmail.com");
            AddUser("ShweYe", "shwe12", "psw123", "shweyi@gmail.com");
            AddUser("Thiri", "thiri12", "psw123", "thiri@gmail.com");
            AddUser("KyawKyaw", "kyaw12", "psw123", "kyawkyaw@gmail.com");
            AddUser("SoeSoe", "soe12", "psw123", "soesoe@gmail.com");
            AddUser("WinWin", "win12", "psw123", "winwin@gmail.com");
            AddUser("Thazin", "thazin12", "psw123", "thazin@gmail.com");
            AddUser("MyaMya", "mya12", "psw123", "myamya@gmail.com");
            AddUser("Yamin", "yamin12", "psw123", "yamin@gmail.com");
            AddUser("YiYi", "yi12", "psw123", "yiyi@gmail.com");
            AddUser("Oakkar", "oak12", "psw123", "oakkar@gmail.com");
            AddUser("KaungHtetSwe", "kaung12", "psw123", "kaunghtetswe@gmail.com");
            AddUser("YeMinAung", "ye12", "psw123", "yeminaung@gmail.com");
            AddUser("KyiSinThein", "kyi12", "psw123", "kyisinthein@gmail.com");
            AddUser("MinThein", "min12", "psw123", "minthein@gmail.com");
            AddUser("MyoMin", "min12", "psw123", "myomin@gmail.com");
            AddUser("AungPhyo", "phyo12", "psw123", "aungphyo@gmail.com");
        }
        public void AddUser(string name,string username, string password, string email)
        {

            SqlCommand cmd = new SqlCommand("insert into users(username,email,fullname,password) values(@username,@email,@fullname,@password)", cn);
            string psw = HashPsw(password);
            try
            {
                cn.Open();
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("fullname", name);
                cmd.Parameters.AddWithValue("password", psw);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("select id from users where email=@email", cn);
                cmd1.Parameters.AddWithValue("email", email);
                SqlDataReader rd = cmd1.ExecuteReader();
                string uid = "";
                while (rd.Read())
                {
                    uid = rd["id"].ToString();
                }
                rd.Close();
                SqlCommand cmd2 = new SqlCommand("insert into subscriptions (user_id,plan_id,bookLimit,status,isUnlimited) values (@uid,1,3,1,0)", cn);
                cmd2.Parameters.AddWithValue("uid", uid);
                cmd2.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex) { Console.Write(ex.Message); }
        }
        private string HashPsw(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

}