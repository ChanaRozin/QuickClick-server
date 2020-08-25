using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuestionDAL
    {
        public static Question addQuestion(Question question)
        {

            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {


               var q=    db1.Questions.Add(question);
                    db1.SaveChanges();
                    return q;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool daleteQuestion(int idQuestion)
        {
            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {



                    db1.Questions.Remove(db1.Questions.Where(q => q.questionId == idQuestion).FirstOrDefault());
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool updateQuestion(Question question)
        {
            try
            {
                using (QuizTriviaEntities ts = new QuizTriviaEntities())
                {
                    ts.Questions.Where(w => w.questionId == question.questionId).FirstOrDefault().questionText = question.questionText;
                    ts.SaveChanges();
                    return true;
                }


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Question> MyListQuestion(int idQuiz)
        {
            try
            {
                using (QuizTriviaEntities ts = new QuizTriviaEntities())
                {
                    return ts.Questions.Where(p => p.quizId == idQuiz).ToList();


                }


            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
}
  