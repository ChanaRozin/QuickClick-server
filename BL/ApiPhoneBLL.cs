using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ApiPhoneBLL
    {

        public static bool useQuizPlay(int quizId)
        {
            return ApiPhoneDAL.useQuizPlay(quizId);

        }
        public static bool addQuestionToUseQuiz(int quizId, int questionId)
        {
            return ApiPhoneDAL.addQuestionToUseQuiz(quizId, questionId);
        }
        public static bool updateConnectionPlayer(string apiPhone)
        {
            return ApiPhoneDAL.updateConnectionPlayer(apiPhone);
        }

        public static bool addAnswerPlayer(string apiPhone, int? answer, int answerToQuestion)
        {
            return ApiPhoneDAL.addAnswerPlayer(apiPhone, answer, answerToQuestion);
        }

        public static List<string> theFastPlayers(int quizId, int questionId, int correctAnswer)
        {
            return ApiPhoneDAL.theFastPlayers(quizId, questionId, correctAnswer);
        }

        public static bool addPltayersToUseQuizPlay(int quizId)
        {
            return ApiPhoneDAL.addPltayersToUseQuizPlay(quizId);
        }

        public static List<string> theWinners(int quizId)
        {
            return ApiPhoneDAL.theWinners(quizId);
        }
        public static List<string> leadingPlayers(int quizId)
        {
            return ApiPhoneDAL.leadingPlayers(quizId);
        }

        public static bool removeQuiz(int quizId)
        {
            return ApiPhoneDAL.removeQuiz(quizId);
        }

        public static int getNumPlayersQuiz(int quizId)
        {
            return ApiPhoneDAL.getNumPlayersQuiz(quizId);
        }

        public static int getNumPlayersPlay(int quizId)
        {
            return ApiPhoneDAL.getNumPlayersPlay(quizId);
        }

        public static List<int> answersPlayers(int quizId, int questionId)
        {
            return ApiPhoneDAL.answersPlayers(quizId, questionId);
        }
    }
}
