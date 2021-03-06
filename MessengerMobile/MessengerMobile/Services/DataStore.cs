using System;
using MessengerMobile.Models;

namespace MessengerMobile.Services
{
    internal class DataStore
    {
        public static DataStore Instance => _instance ??= new DataStore();
        
        public UserModel User { get; set; }
        
        public Guid DebugUserGuid { get; } = Guid.Parse("3F131756-CEF6-46F0-A7E4-92858F77DFE3");

        public IWebClient WebClient { get; } = new MockWebClient();

        #region PrivatePart

        private static DataStore _instance;

        private DataStore()
        {
        }

        #endregion
    }
}