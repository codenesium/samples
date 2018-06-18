using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOChain: AbstractBusinessObject
        {
                public AbstractBOChain() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  int chainStatusId,
                                                  Guid externalId,
                                                  string name,
                                                  int teamId)
                {
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                        this.TeamId = teamId;
                }

                public int ChainStatusId { get; private set; }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int TeamId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1dcf494286b14808c7569581244fd857</Hash>
</Codenesium>*/