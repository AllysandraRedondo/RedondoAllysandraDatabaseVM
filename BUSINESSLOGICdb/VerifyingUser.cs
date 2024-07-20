using DATALAYERdb;
using MODELSdb;


namespace BUSINESSLOGICdb
{
    public class VerifyingUser
    {

        OwnerData data = new OwnerData();

        public List<OwnerContent> GetAllUsers(string username, string password)
        {
            OwnerContent o = new OwnerContent { username = username, password = password};
            return data.GetUsers();
        }

    }
}
