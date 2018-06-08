using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOChain: AbstractBusinessObject
        {
                public BOChain() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>cc415f85f59754b13229a2f16f29cf46</Hash>
</Codenesium>*/