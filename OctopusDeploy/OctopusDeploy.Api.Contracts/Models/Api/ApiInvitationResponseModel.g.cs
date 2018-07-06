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

                public string Id { get; private set; }

                public string InvitationCode { get; private set; }

                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>834dd4c873635c3afe16574811c12977</Hash>
</Codenesium>*/