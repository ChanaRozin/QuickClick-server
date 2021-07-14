using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;

namespace ApiClick1.Controllers
{
    
    [RoutePrefix("api/quizes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuizController : ApiController
    {
        [HttpPost]
        [Route("addQuiz")]
        public IHttpActionResult AddQuiz([FromBody]DTO.DtoQuiz quiz)
        {
            DTO.DtoQuiz quizDto = BL.QuizBLL.AddQuiz(quiz);
            if (quizDto != null)
                return Ok(quizDto);
            return BadRequest();//אולי להחזיר null
        }
        [HttpGet]
        [Route("getListQuiz/{idUser}")]
        public IHttpActionResult MyListQuiz([FromUri]int idUser)

        {
            List<DtoQuiz> myListQuiz = QuizBLL.MyListQuiz(idUser);
            if (myListQuiz != null)
                return Ok(myListQuiz);
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpDelete]

        public IHttpActionResult deleteQuiz([FromUri]int idQuiz)
        {

            if (BL.QuizBLL.deleteQuiz(idQuiz))
                return Ok();
            return BadRequest();
        }


    }
}
