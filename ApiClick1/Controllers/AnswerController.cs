using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiClick1.Controllers
{
    [RoutePrefix("api/answers")]
    public class AnswerController : ApiController
    {
        [HttpPost]
        [Route("addAnswer")]
        public IHttpActionResult AddAnswer([FromBody]DTO.DtoAnswer answer)

        {

            if (AnswerBLL.AddAnswer(answer))
                return Ok();
            else
                return BadRequest();
        }
        [HttpDelete]
        [Route("deleteAnswer/{idAnswer}")]
        public IHttpActionResult deleteAnswer([FromUri] int idAnswer)

        {
            if (AnswerBLL.deleteAnswer(idAnswer))
                return Ok("true");
            else
                return BadRequest("false");




        }
        [HttpGet]
        [Route("getListAnswers/{idQuiz}")]
        public IHttpActionResult getListAnswers(int idQuiz)

        {
            List<DtoAnswer> myListAnswers = AnswerBLL.ListAnswers(idQuiz);
            if (myListAnswers != null)
                return Ok(myListAnswers);
            return BadRequest();//אולי להחזיר null
        }
        [HttpPut]
        [Route("updateAnswer")]
        public IHttpActionResult updateAnswer([FromBody]DtoAnswer answer)

        {
            if (AnswerBLL.updateAnswer(answer) == true)
                return Ok();
            else
                return BadRequest();

        }

    }
    }
