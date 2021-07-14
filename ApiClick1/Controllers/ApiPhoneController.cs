using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace ApiClick1.Controllers
{
    [RoutePrefix("api/apiPhone")]
    public class ApiPhoneController : ApiController
    {

        [HttpGet]
        [Route("useQuizPlay/{quizId}")]
        public IHttpActionResult useQuizPlay([FromUri]int quizId)

        {

            if (ApiPhoneBLL.useQuizPlay(quizId) && ApiPhoneBLL.addPltayersToUseQuizPlay(quizId))
                return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("addQuestionToUseQuiz/{quizId}/{questionId}")]
        public IHttpActionResult addQuestionToUseQuiz([FromUri]int quizId, [FromUri]int questionId)

        {

            if (ApiPhoneBLL.addQuestionToUseQuiz(quizId, questionId))
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        [Route("theFastPlayers/{quizId}/{questionId}/{correctAnswer}")]
        public IHttpActionResult theFastPlayers([FromUri]int quizId, [FromUri]int questionId, [FromUri]int correctAnswer)

        {
            List<string> players = ApiPhoneBLL.theFastPlayers(quizId, questionId, correctAnswer);
            if (players != null)
                return Ok(players);
            return BadRequest();
        }
        [HttpGet]
        [Route("theWinners/{quizId}")]
        public IHttpActionResult theWinners([FromUri]int quizId)

        {
            List<string> theWinners = ApiPhoneBLL.theWinners(quizId);
            if (theWinners != null)
                return Ok(theWinners);
            return BadRequest();
        }
        [HttpGet]
        [Route("leadingPlayers/{quizId}")]
        public IHttpActionResult leadingPlayers([FromUri]int quizId)

        {
            List<string> leadingPlayers = ApiPhoneBLL.leadingPlayers(quizId);
            if (leadingPlayers != null)
                return Ok(leadingPlayers);
            return BadRequest();
        }
        [HttpDelete]
        [Route("removeQuiz/{quizId}")]
        public IHttpActionResult removeQuiz([FromUri]int quizId)

        {

            if (ApiPhoneBLL.removeQuiz(quizId))
                return Ok();
            return BadRequest();
        }
        [HttpGet]
        [Route("getNumPlayersQuiz/{quizId}")]
        public IHttpActionResult getNumPlayersQuiz([FromUri]int quizId)

        {
            int getNumPlayersQuiz = ApiPhoneBLL.getNumPlayersQuiz(quizId);
            if (getNumPlayersQuiz != 0)
                return Ok(getNumPlayersQuiz);
            return BadRequest();
        }
        [HttpGet]
        [Route("getNumPlayersPlay/{quizId}")]
        public IHttpActionResult getNumPlayersPlay([FromUri]int quizId)

        {
            int getNumPlayersPlay = ApiPhoneBLL.getNumPlayersPlay(quizId);
            if (getNumPlayersPlay != 0)
                return Ok(getNumPlayersPlay);
            return BadRequest();
        }
        [HttpGet]
        [Route("answersPlayers/{quizId}/{questionId}")]
        public IHttpActionResult answersPlayers([FromUri]int quizId, [FromUri]int questionId)

        {
            List<int> answersPlayers = ApiPhoneBLL.answersPlayers(quizId, questionId);
            if (answersPlayers != null)
                return Ok(answersPlayers);
            return BadRequest();
        }

    }


}
