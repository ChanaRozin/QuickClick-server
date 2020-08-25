using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
 public class Password
    {
     
        public static string GenerateString(int size)
        {
            Random rand = new Random();

          string Alphabet =
        "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }
        public static bool SendMail(DtoUser user)
        {
            string to=null;
            string password;
            string firstName;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("quickclick.play@gmail.com");
                to =user.email ;
                if (to!=null)
                mail.To.Add(to);
                 password = GenerateString(8);
                firstName = UserDAL.getNameUserByEmail(user.email);
                mail.Subject = "סיסמה זמנית";
                mail.Body ="הי"+" "+firstName+"\n"+ "סיסמתך הזמנית היא:"+ password;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("quickclick.play@gmail.com", "Quick_Click");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                if (UserDAL.UpdatePassword(user.email, password) ==false)
                    return false;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
