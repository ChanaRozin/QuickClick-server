using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class AnswerDAL
    {
        public static bool AddAnswer(Answer answer)
        {

            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {


                    db1.Answers.Add(answer);
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool deleteAnswer(int idAnswer)
        {
            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                db1.Answers.Remove(db1.Answers.Where(p => p.answerId == idAnswer).FirstOrDefault());
                db1.SaveChanges();
                return true;
            }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool updateAnswer(Answer answer)
        {
            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {

                    db1.Answers.Where(a => a.answerId == answer.answerId).FirstOrDefault().answerText = answer.answerText;
                    db1.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Answer> ListAnswers(int idQuiz)
        {
            try
            {
                using (QuizTriviaEntities db1 = new QuizTriviaEntities())
                {
                List< Question> listQuestion = db1.Quizs.Where(p => p.quizId == idQuiz).FirstOrDefault().Questions.ToList();
                    List<Answer> listAnswers = new List<Answer>();
                     listQuestion.ForEach(q => q.Answers.ToList().ForEach(a=>listAnswers.Add(a)));
                    return listAnswers;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
    }
}
