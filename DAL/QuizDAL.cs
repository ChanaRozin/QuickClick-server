using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class QuizDAL
    {
        public static Quiz AddQuiz(Quiz quiz)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    var q = db1.Quizs.Add(quiz);
                    db1.SaveChanges();

                    return q;


                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Quiz> MyListQuiz(int userId)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {
                    return db1.Quizs.Where(p => p.userId == userId).ToList();

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool deleteQuiz(int idQuiz)
        {
            try
            {

                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    db1.Quizs.Remove(db1.Quizs.Where(p => p.quizId == idQuiz).FirstOrDefault());
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

