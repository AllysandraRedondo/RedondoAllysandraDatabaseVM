using DATALAYERdb;
using MODELSdb;


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
