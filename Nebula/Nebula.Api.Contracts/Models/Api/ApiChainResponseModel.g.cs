using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiChainResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int chainStatusId,
                        Guid externalId,
                        string name,
                        int teamId)
                {
                        this.Id = id;
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Name = name;
                        this.TeamId = teamId;

                        this.ChainStatusIdEntity = nameof(ApiResponse.ChainStatus);
                        this.TeamIdEntity = nameof(ApiResponse.Teams);
                }

                public int ChainStatusId { get; private set; }

                public string ChainStatusIdEntity { get; set; }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int TeamId { get; private set; }

                public string TeamIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>084e1547e41635051b9ae64315308105</Hash>
</Codenesium>*/