using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ApiClick1.Controllers
{
    public class VoiceController : ApiController
    {

        public HttpResponseMessage AnswerQuestions(string ApiPhone, int a)
        {

            HttpResponseMessage response = new HttpResponseMessage();
           

                response.Content = new StringContent("read=t-" ,
                                            Encoding.UTF8, "text/html");
                return response;


            
        }
    }
}
