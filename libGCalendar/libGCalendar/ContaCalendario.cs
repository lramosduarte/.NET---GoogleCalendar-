using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace libGCalendar
{
    class ContaCalendario
    {
        private ClientSecrets token = new ClientSecrets();


        public ContaCalendario(string clientId, string clientSecret)
        {
            token.ClientId = clientId;
            token.ClientSecret = clientSecret;
        }


        public ClientSecrets Token
        { 
            get 
            {
                return token;
            } 
        }
    }
}
