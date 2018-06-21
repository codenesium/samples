using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiInvitationResponseModel : AbstractApiResponseModel
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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeInvitationCodeValue { get; set; } = true;

                public bool ShouldSerializeInvitationCode()
                {
                        return this.ShouldSerializeInvitationCodeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeInvitationCodeValue = false;
                        this.ShouldSerializeJSONValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d5a135dab2317f2225223885e9539310</Hash>
</Codenesium>*/