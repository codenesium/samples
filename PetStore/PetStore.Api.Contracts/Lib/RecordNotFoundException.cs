using System;

namespace PetStoreNS.Api.Contracts
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException()
        {
        }

        public RecordNotFoundException(string message) 
            : base(message)
        {
        }
    }
}