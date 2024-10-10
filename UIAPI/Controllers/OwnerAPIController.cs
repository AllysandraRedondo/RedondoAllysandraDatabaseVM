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
        public JsonResult RemoveAnime(AnimeContent title)
        {
            var r = aniproc.RemoveAnime(title);
            return new JsonResult(r);

        }
        [HttpGet("searchanime")]
        public IEnumerable<AnimeContent> SearchAnime(string AnyInfo)
        {
            return aniproc.SearchAnime(AnyInfo);

        }

        [HttpPatch("updateanime")]
        public JsonResult UpdateAnime(AnimeContent AnyInfo)
        {
            var r = aniproc.UpdateAnime(AnyInfo);
            return new JsonResult(r);
        }
    }
}
