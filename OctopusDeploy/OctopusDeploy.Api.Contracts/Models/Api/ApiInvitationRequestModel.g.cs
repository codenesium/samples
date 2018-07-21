using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInvitationRequestModel : AbstractApiRequestModel
        {
                public ApiInvitationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string invitationCode,
                        string jSON)
                {
                        this.InvitationCode = invitationCode;
                        this.JSON = jSON;
                }

                [JsonProperty]
                public string InvitationCode { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2c7cf9b5ce5b54c1a1ce38d73598c058</Hash>
</Codenesium>*/