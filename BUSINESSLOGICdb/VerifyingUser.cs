using DATALAYERdb;
using MODELSdb;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace BUSINESSLOGICdb
{
    public class VerifyingUser
    {

        OwnerData data = new OwnerData();

        public List<OwnerContent> GetAllUsers()
        {
            return data.GetUsers();
        }

    }
}
