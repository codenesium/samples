using System;

namespace ESPIOTNS.Api.Contracts
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