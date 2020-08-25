using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 public class DtoQuiz
    {
        public int quizId { get; set; }
        public string quizName { get; set; }
        public Nullable<int> userId { get; set; }
    }
}
