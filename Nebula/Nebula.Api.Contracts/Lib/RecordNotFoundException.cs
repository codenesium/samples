using System;

namespace NebulaNS.Api.Contracts
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