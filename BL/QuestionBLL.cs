using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class QuestionBLL
    {

        public static DTO.DtoQuestion addquestion(DTO.DtoQuestion questionDto)
        {Question question= QuestionDAL.addQuestion(Converts.QuestionConvert.FromDtoToDal(questionDto));
            if (question != null)
                return Converts.QuestionConvert.FromDalToDto(question);
            return null;

        }

        public static bool deleteQuestion(int idQuestion)
        {
            return QuestionDAL.daleteQuestion(idQuestion);
        }
        public static List<DtoQuestion> myListQuestions(int idQuiz)
        {

            return Converts.QuestionConvert.ListFromDalToDto(QuestionDAL.MyListQuestion(idQuiz));
        }

        public static bool updateQuestion(DtoQuestion question)
        {
            return QuestionDAL.updateQuestion(Converts.QuestionConvert.FromDtoToDal(question));
        }

        
    }
}