using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BL
{
    public class QuizBLL
    {
        public static DtoQuiz AddQuiz(DtoQuiz quizDto)
        {
            Quiz quiz = QuizDAL.AddQuiz(Converts.QuizConvert.fromDtoToDal(quizDto)); 
            if (quiz != null)
        return Converts.QuizConvert.fromDalToDto(quiz);
            return null;



        }
        public static List<DtoQuiz> MyListQuiz(int userid)
        {

            return Converts.QuizConvert.ListFromDalToDto(QuizDAL.MyListQuiz(userid));


        }
        public static bool deleteQuiz(int idQuiz)
        {

            return QuizDAL.deleteQuiz(idQuiz);
        }

    }
}