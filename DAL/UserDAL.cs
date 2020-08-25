using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        public static bool Register(User user,int quizId)
        {

            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {


                     var u= db1.Users.Add(user);
                    db1.SaveChanges();
                    if (quizId != 0)
                    {
                        db1.Quizs.Where(q => q.quizId == quizId).FirstOrDefault().Users.Add(u);
                    
                        db1.Users.Where(q => q.userId == u.userId).FirstOrDefault().Quizs1.Add(db1.Quizs.Where(q => q.quizId == quizId).FirstOrDefault());
                      
                    }
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static User Login(string usercode, string password)
        {

            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    User user = db1.Users.Where(p => p.email == usercode && p.pasword == password).FirstOrDefault();
                    if (user != null)
                        return user;
                    return null;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool updatePlayer(User user)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                   db1.Users.Where(p => p.userId == user.userId).FirstOrDefault().fullName = user.fullName;
                    db1.Users.Where(p => p.userId == user.userId).FirstOrDefault().phone = user.phone;
                    db1.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool DeletePlayer(int userId)
        {

            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {


                    db1.Users.Where(u => u.userId == userId).FirstOrDefault().Quizs1.Remove(db1.Users.Where(u => u.userId == userId).FirstOrDefault().Quizs1.FirstOrDefault());
                    db1.Users.Remove(db1.Users.Where(a => a.userId == userId).FirstOrDefault());

                
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdatePassword(string email , string password)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                   db1.Users.Where(u => u.email == email).FirstOrDefault().pasword=password;
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static string getNameUserByEmail(string email)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                { string firstName;
                    firstName= db1.Users.Where(u => u.email == email).FirstOrDefault().fullName.ToString();
               
                    return firstName.ToString().Trim().Split(' ')[0];

                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static List<User> listPlayers(int idQuiz)
        {
            try
            {
                using (QuizTriviaEntities v = new QuizTriviaEntities())
                {

                    return v.Quizs.Where(p => p.quizId == idQuiz).FirstOrDefault().Users.Where(u => u.isRegistered == false).ToList();

                }


            }
            catch (Exception e)
            {
                return null;
            }
        }


    }



}

