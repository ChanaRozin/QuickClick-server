using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converts
{
    public class AnswerConvert
    {
        public static DtoAnswer FromDalToDto(Answer answerDal)
        {
            DtoAnswer answerDto = new DtoAnswer()
            {
                questionId = answerDal.questionId,
                isCorrect = answerDal.isCorrect,
                answerText = answerDal.answerText,
                answerId = answerDal.answerId
            };
            return answerDto;
        }
        public static Answer FromDtoToDal(DtoAnswer answerDto)
        {
            Answer answerDal = new Answer()

            {
                questionId = answerDto.questionId,
                isCorrect = answerDto.isCorrect,
                answerText = answerDto.answerText,
                answerId = answerDto.answerId
            };
            return answerDal;
        }
        public static List<DtoAnswer> ListFromDalToDto(List<Answer> answerDto)
        {
            List<DtoAnswer> answers = new List<DtoAnswer>();
            answerDto.ForEach(a => answers.Add(FromDalToDto(a)));
            return answers;
        }
    }
}
