using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiTeamResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string environmentIds,
                        string id,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                public string EnvironmentIds { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string MemberUserIds { get; private set; }

                public string Name { get; private set; }

                public string ProjectGroupIds { get; private set; }

                public string ProjectIds { get; private set; }

                public string TenantIds { get; private set; }

                public string TenantTags { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdsValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentIds()
                {
                        return this.ShouldSerializeEnvironmentIdsValue;
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
                public bool ShouldSerializeMemberUserIdsValue { get; set; } = true;

                public bool ShouldSerializeMemberUserIds()
                {
                        return this.ShouldSerializeMemberUserIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectGroupIdsValue { get; set; } = true;

                public bool ShouldSerializeProjectGroupIds()
                {
                        return this.ShouldSerializeProjectGroupIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdsValue { get; set; } = true;

                public bool ShouldSerializeProjectIds()
                {
                        return this.ShouldSerializeProjectIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdsValue { get; set; } = true;

                public bool ShouldSerializeTenantIds()
                {
                        return this.ShouldSerializeTenantIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantTagsValue { get; set; } = true;

                public bool ShouldSerializeTenantTags()
                {
                        return this.ShouldSerializeTenantTagsValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEnvironmentIdsValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeMemberUserIdsValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProjectGroupIdsValue = false;
                        this.ShouldSerializeProjectIdsValue = false;
                        this.ShouldSerializeTenantIdsValue = false;
                        this.ShouldSerializeTenantTagsValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>4b38ffc9e2851d7b510a38c37859f977</Hash>
</Codenesium>*/