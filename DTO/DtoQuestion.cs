using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DtoQuestion
    {
        public int questionId { get; set; }
        public string questionText { get; set; }
        public Nullable<bool> isSurvey { get; set; }
        public Nullable<int> quizId { get; set; }
    }
}
