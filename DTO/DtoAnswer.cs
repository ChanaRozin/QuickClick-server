using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class DtoAnswer
    {
        public int answerId { get; set; }
        public Nullable<int> questionId { get; set; }
        public string answerText { get; set; }
        public Nullable<bool> isCorrect { get; set; }
    }
}
