using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ApiClick1.Controllers
{
    public class VoiceController : ApiController
    {
        [HttpGet]
        [Route("api/voice/answers")]
        public HttpResponseMessage AnswerQuestions(string ApiPhone, int? answer = null)

        {
            int? quizId = answer;
            string apiPhone = ApiPhone;
            HttpResponseMessage response = new HttpResponseMessage();

            if (answer == null)
            {
                response.Content = new StringContent("read=t-הקש את קוד המשחק שמופיע על המסך=answer,No,2,1,10,No,Yes,Yes,*/&",
                                            Encoding.UTF8, "text/html");
            }
            else
            {
                string request = Request.RequestUri.AbsoluteUri;
                int answerToQuestion = int.Parse(request.Substring(request.Length - 1));
                response.Content = new StringContent("read=t-תשובתך התקבלה=answer,No,1,1,10,No,Yes,Yes,*/&",
                                            Encoding.UTF8, "text/html");
                if (request.Substring(request.Length - 2).Contains('='))
                    ApiPhoneBLL.addAnswerPlayer(ApiPhone, answer, answerToQuestion);
            }
            return response;
        }

    }
}
