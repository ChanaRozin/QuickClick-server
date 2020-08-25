using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converts
{
    class QuestionConvert
    {
        public static DtoQuestion FromDalToDto(Question questionDal)
        {
            DtoQuestion questionDto = new DtoQuestion()
            {
                quizId = questionDal.quizId,
                questionText = questionDal.questionText,
                questionId= questionDal.questionId,
                isSurvey= questionDal.isSurvey

            };
            return questionDto;

        }
        public static Question FromDtoToDal(DtoQuestion questionDto)
        {
            Question questionDal = new Question()
            {
                quizId = questionDto.quizId,
                questionText = questionDto.questionText,
                questionId = questionDto.questionId,
                isSurvey = questionDto.isSurvey

            };
            return questionDal;

        }
        public static List<DtoQuestion> ListFromDalToDto(List<Question> questiondto)
        {
            List<DtoQuestion> questions = new List<DtoQuestion>();
            questiondto.ForEach(a => questions.Add( FromDalToDto (a)));
            return questions;
        }

      

    }
}
