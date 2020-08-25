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
    [RoutePrefix("api/users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("register/{quizId}")]
        public IHttpActionResult Register([FromBody]DTO.DtoUser user,[FromUri]int quizId)

        {

            if (UsersBLL.Register(user,quizId))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        [Route("login/{usercode}/{password}")]
        public IHttpActionResult Login([FromUri]string usercode, [FromUri]string password)

        {
            DtoUser user = UsersBLL.Login(usercode, password);
            if (user != null)
                return Ok(user);
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpDelete]
        [Route("delete/{userId}")]
        public IHttpActionResult DeletePlayer([FromUri]int userId)

        {

            if (UsersBLL.DeletePlayer(userId))
                return Ok();
            else
                return BadRequest();//אולי להחזיר null
        }
        [HttpPut]
        [Route("getPassword")]

        public IHttpActionResult getPassword([FromBody]DtoUser user)

        {
          if(Password.SendMail(user) ==true)
                return Ok();
            else
            return BadRequest();
               
        }
        [HttpPut]
        [Route("updatePlayer")]

        public IHttpActionResult updatePlayer([FromBody]DtoUser user)

        {
            if (UsersBLL.updatePlayer(user) == true)
                return Ok();
            else
                return BadRequest();

        }
        [Route("getUserById/{userId}")]

        //public IHttpActionResult getUserById([FromUri]int userId)

        //{
        //    if (Password.SendMail(userId) == true)
        //        return Ok();
        //    else
        //        return BadRequest();

        //}
        [HttpGet]
        [Route("getAllPlayers/{idQuiz}")]
        public IHttpActionResult getAllPlayers([FromUri] int idQuiz)
        {
            List<DtoUser> myListPlayers = UsersBLL.myListPlayers(idQuiz);

            if (myListPlayers != null)
                return Ok(myListPlayers);
            else
                return BadRequest();//אולי להחזיר null
        }
    }

}
