using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiTenantVariableResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string environmentId,
                        string id,
                        string jSON,
                        string ownerId,
                        string relatedDocumentId,
                        string tenantId,
                        string variableTemplateId)
                {
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentId = relatedDocumentId;
                        this.TenantId = tenantId;
                        this.VariableTemplateId = variableTemplateId;
                }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string OwnerId { get; private set; }

                public string RelatedDocumentId { get; private set; }

                public string TenantId { get; private set; }

                public string VariableTemplateId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEnvironmentIdValue { get; set; } = true;

                public bool ShouldSerializeEnvironmentId()
                {
                        return this.ShouldSerializeEnvironmentIdValue;
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
                public bool ShouldSerializeOwnerIdValue { get; set; } = true;

                public bool ShouldSerializeOwnerId()
                {
                        return this.ShouldSerializeOwnerIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentId()
                {
                        return this.ShouldSerializeRelatedDocumentIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVariableTemplateIdValue { get; set; } = true;

                public bool ShouldSerializeVariableTemplateId()
                {
                        return this.ShouldSerializeVariableTemplateIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeOwnerIdValue = false;
                        this.ShouldSerializeRelatedDocumentIdValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                        this.ShouldSerializeVariableTemplateIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>50e31d48ed39e2b4aec7434371945677</Hash>
</Codenesium>*/