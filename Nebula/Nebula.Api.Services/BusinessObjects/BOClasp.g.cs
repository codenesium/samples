using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOClasp: AbstractBusinessObject
        {
                public BOClasp() : base()
                {
                }

                public void SetProperties(int id,
                                          int nextChainId,
                                          int previousChainId)
                {
                        this.Id = id;
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;
                }

                public int Id { get; private set; }

                public int NextChainId { get; private set; }

                public int PreviousChainId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>244202ea533c56720bf98b4e0dce537e</Hash>
</Codenesium>*/