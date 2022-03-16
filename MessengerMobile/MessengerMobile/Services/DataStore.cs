using System;

namespace MessengerMobile.Services
{
    public class DataStore
    {
        public DataStore Instance => _instance ??= new DataStore();
        
        public Guid UserGuid { get; set; }

        #region PrivatePart

        private DataStore _instance;

        private DataStore()
        {
        }

        #endregion
    }
}