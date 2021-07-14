using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DTO;
namespace ApiClick1.Controllers
{
    [RoutePrefix("api/questions")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionnController : ApiController
    {
        [HttpPost]
        [Route("addQuestion")]
        public IHttpActionResult AddQuestion([FromBody]DTO.DtoQuestion question)

        {
            DTO.DtoQuestion questionDto = QuestionBLL.addquestion(question);

            if (questionDto != null)
                return Ok(questionDto);
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpGet]
        [Route("getListQuestions/{idQuiz}")]
        public IHttpActionResult getListQuestions([FromUri]int idQuiz)

        {
            List<DtoQuestion> myListQuestions = myListQuestions = QuestionBLL.myListQuestions(idQuiz);

            if (myListQuestions != null)
                return Ok(myListQuestions);
            else
                return BadRequest();//אולי להחזיר null
        }

        [HttpDelete]
        [Route("deleteQuestion/{idQuestion}")]
        public IHttpActionResult deleteQuestion([FromUri]int idQuestion)
        {

            if (BL.QuestionBLL.deleteQuestion(idQuestion))
                return Ok(true);
            return BadRequest();
        }
        [HttpPut]
        [Route("updateQuestion")]
        public IHttpActionResult updateQuestion([FromBody]DtoQuestion question)

        {
            if (QuestionBLL.updateQuestion(question) == true)
                return Ok();
            else
                return BadRequest();

        }

    }
}
