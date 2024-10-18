using Microsoft.AspNetCore.Mvc;
using BUSINESSLOGICdb;
using MODELSdb;


namespace OwnerAPIController.Controllers
{
    [ApiController]
    [Route("controller/")]
    public class OwnerAPIController : ControllerBase
    {

        private VerifyingUser veruser;
        private AnimeProcess aniproc;


        public OwnerAPIController()
        {
            veruser = new VerifyingUser();
            aniproc = new AnimeProcess();
        }

        [HttpGet("user")]
        public IEnumerable<OwnerContent> GetAllUsers()
        {
            return veruser.GetAllUsers();
        }



        [HttpPost("Adduser")]
        public JsonResult Adduser(OwnerContent ownerContent)
        {

            var r = veruser.AddUser(ownerContent);
            return new JsonResult(r);
        }

        [HttpDelete("deleteuser")]
        public JsonResult RemoveUser(string user)
        {
            int result = veruser.RemoveUser(user);

            if (result == 1)
            {
                return new JsonResult(result);
            }
            else
            {
                return new JsonResult(new { message = "User not found." });
            }
        }

        [HttpPatch("updateuser")]
        public JsonResult UpdateUser(OwnerContent AnyInfo)
        {
            var r = veruser.UpdateUser(AnyInfo);
            return new JsonResult(r);
        }
        //---------------------------------------------------------------------------------------------------------
 
        [HttpGet("anime")]
        public IEnumerable<AnimeContent> GetAllAnime()
        {
            return aniproc.GetAllAnime();
        }

        [HttpPost("Addanime")]
        public JsonResult AddAnime(AnimeContent animeContent)
        {

            var r = aniproc.AddAnime(animeContent);
            return new JsonResult(r);
        }


        [HttpDelete("deleteanime")]
        public JsonResult RemoveAnime(string title)
        {
            int result = aniproc.RemoveAnime(title);

            if (result == 1)
            {
                return new JsonResult(result);
            }
            else
            {
                return new JsonResult(new {message = "Anime not found." });
            }
        }

        [HttpPatch("updateanime")]
        public JsonResult UpdateAnime(AnimeContent AnyInfo)
        {
            var r = aniproc.UpdateAnime(AnyInfo);
            return new JsonResult(r);
        }



    }
}
