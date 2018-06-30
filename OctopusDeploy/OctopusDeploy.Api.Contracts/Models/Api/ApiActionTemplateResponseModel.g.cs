using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string actionType,
                        string communityActionTemplateId,
                        string jSON,
                        string name,
                        int version)
                {
                        this.Id = id;
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                public string ActionType { get; private set; }

                public string CommunityActionTemplateId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeActionTypeValue { get; set; } = true;

                public bool ShouldSerializeActionType()
                {
                        return this.ShouldSerializeActionTypeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCommunityActionTemplateIdValue { get; set; } = true;

                public bool ShouldSerializeCommunityActionTemplateId()
                {
                        return this.ShouldSerializeCommunityActionTemplateIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeActionTypeValue = false;
                        this.ShouldSerializeCommunityActionTemplateIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>6f5cea838fb14c05dfd45ad75bfc0bea</Hash>
</Codenesium>*/