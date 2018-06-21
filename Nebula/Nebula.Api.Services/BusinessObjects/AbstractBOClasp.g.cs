using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOClasp : AbstractBusinessObject
        {
                public AbstractBOClasp()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>2527f257b0841cf7d228a89b92a075a8</Hash>
</Codenesium>*/