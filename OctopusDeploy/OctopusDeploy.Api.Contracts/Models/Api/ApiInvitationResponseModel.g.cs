using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInvitationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string invitationCode,
                        string jSON)
                {
                        this.Id = id;
                        this.InvitationCode = invitationCode;
                        this.JSON = jSON;
                }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string InvitationCode { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cdfaa880425ec6c6e695c5109d44ff4e</Hash>
</Codenesium>*/