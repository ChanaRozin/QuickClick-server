using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
   public class AnswerBLL
    {
        
        public static bool AddAnswer(DtoAnswer answer)
        {
            return AnswerDAL.AddAnswer(Converts.AnswerConvert.FromDtoToDal(answer));
        }
        public static bool deleteAnswer(int idAnswer)
        {
            return AnswerDAL.deleteAnswer(idAnswer);
            
        }
        public static List<DtoAnswer> ListAnswers(int idQuiz)
        {
            List<Answer> ListAnswers = AnswerDAL.ListAnswers(idQuiz);
            if (ListAnswers!=null)
            return Converts.AnswerConvert.ListFromDalToDto(ListAnswers);
            return null;

        }

        public static bool updateAnswer(DtoAnswer answer)
        {
            return AnswerDAL.updateAnswer(Converts.AnswerConvert.FromDtoToDal(answer));
        }
    }
 
}
