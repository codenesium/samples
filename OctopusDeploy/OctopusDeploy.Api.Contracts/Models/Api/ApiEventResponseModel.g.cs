using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiEventResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        long autoId,
                        string category,
                        string environmentId,
                        string id,
                        string jSON,
                        string message,
                        DateTimeOffset occurred,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId,
                        string userId,
                        string username)
                {
                        this.AutoId = autoId;
                        this.Category = category;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Message = message;
                        this.Occurred = occurred;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                        this.UserId = userId;
                        this.Username = username;
                }

                public long AutoId { get; private set; }

                public string Category { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Message { get; private set; }

                public DateTimeOffset Occurred { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string TenantId { get; private set; }

                public string UserId { get; private set; }

                public string Username { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAutoIdValue { get; set; } = true;

                public bool ShouldSerializeAutoId()
                {
                        return this.ShouldSerializeAutoIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCategoryValue { get; set; } = true;

                public bool ShouldSerializeCategory()
                {
                        return this.ShouldSerializeCategoryValue;
                }

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
                public bool ShouldSerializeMessageValue { get; set; } = true;

                public bool ShouldSerializeMessage()
                {
                        return this.ShouldSerializeMessageValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOccurredValue { get; set; } = true;

                public bool ShouldSerializeOccurred()
                {
                        return this.ShouldSerializeOccurredValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProjectIdValue { get; set; } = true;

                public bool ShouldSerializeProjectId()
                {
                        return this.ShouldSerializeProjectIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdsValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentIds()
                {
                        return this.ShouldSerializeRelatedDocumentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUserIdValue { get; set; } = true;

                public bool ShouldSerializeUserId()
                {
                        return this.ShouldSerializeUserIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUsernameValue { get; set; } = true;

                public bool ShouldSerializeUsername()
                {
                        return this.ShouldSerializeUsernameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAutoIdValue = false;
                        this.ShouldSerializeCategoryValue = false;
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeMessageValue = false;
                        this.ShouldSerializeOccurredValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeRelatedDocumentIdsValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                        this.ShouldSerializeUserIdValue = false;
                        this.ShouldSerializeUsernameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>7d3243bb50532d419513b0673a0a9538</Hash>
</Codenesium>*/