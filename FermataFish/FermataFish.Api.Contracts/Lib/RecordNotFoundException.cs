using System;

namespace FermataFishNS.Api.Contracts
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