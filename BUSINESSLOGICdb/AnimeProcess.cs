using System.Collections.Generic;
using MODELSdb;
using DATALAYERdb;
using System.Security.Cryptography.Xml;

namespace BUSINESSLOGICdb
{
    public class AnimeProcess
    {

        SqlData data = new SqlData();

        public List<AnimeContent> GetAllAnime()
        {
            return data.GetAnime();

        }

        public int AddAnime(AnimeContent anime)
        {
            return data.AddAnime(anime.title, anime.studio, anime.releasedate, anime.status, anime.genre, anime.episodes, anime.summary);
        }


        public int RemoveAnime(string title)
        {
            return data.RemoveAnime(title);
        }

        public List<AnimeContent> SearchAnime(string AnyInfo)
        {

            return data.SearchAnime(AnyInfo);
        }

        public int UpdateAnime(AnimeContent AnyInfo)
        {
            return data.UpdateAAnime(AnyInfo.title, AnyInfo.studio, AnyInfo.releasedate, AnyInfo.status, AnyInfo.genre, AnyInfo.episodes, AnyInfo.summary);
        }

    }
}
