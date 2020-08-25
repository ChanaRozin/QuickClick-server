using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converts
{
    public class QuizConvert
    {
        public static DtoQuiz fromDalToDto(Quiz quizDal)
        {
            DtoQuiz dtoquiz = new DtoQuiz()
            {
                quizId = quizDal.quizId,
                quizName = quizDal.quizName,
                userId = quizDal.userId


            };
            return dtoquiz;

        }
        public static Quiz fromDtoToDal(DtoQuiz quizdto)
        {
            Quiz quiz = new Quiz()
            {
                quizId = quizdto.quizId,
                quizName = quizdto.quizName,
                userId = quizdto.userId
                                                                         
            };
            return quiz;



        }
        public static List<DtoQuiz> ListFromDalToDto(List<Quiz> myListQuiz)
        {
        
            List<DtoQuiz> myListQuizDto = new List<DtoQuiz>();
            myListQuiz.ForEach(a => myListQuizDto.Add(fromDalToDto(a)));
            return myListQuizDto;
        }
    }

}
