using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiInterruptionResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime created,
                        string environmentId,
                        string id,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string responsibleTeamIds,
                        string status,
                        string taskId,
                        string tenantId,
                        string title)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.ResponsibleTeamIds = responsibleTeamIds;
                        this.Status = status;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                        this.Title = title;
                }

                public DateTime Created { get; private set; }

                public string EnvironmentId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string ResponsibleTeamIds { get; private set; }

                public string Status { get; private set; }

                public string TaskId { get; private set; }

                public string TenantId { get; private set; }

                public string Title { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCreatedValue { get; set; } = true;

                public bool ShouldSerializeCreated()
                {
                        return this.ShouldSerializeCreatedValue;
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
                public bool ShouldSerializeResponsibleTeamIdsValue { get; set; } = true;

                public bool ShouldSerializeResponsibleTeamIds()
                {
                        return this.ShouldSerializeResponsibleTeamIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStatusValue { get; set; } = true;

                public bool ShouldSerializeStatus()
                {
                        return this.ShouldSerializeStatusValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaskIdValue { get; set; } = true;

                public bool ShouldSerializeTaskId()
                {
                        return this.ShouldSerializeTaskIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTenantIdValue { get; set; } = true;

                public bool ShouldSerializeTenantId()
                {
                        return this.ShouldSerializeTenantIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTitleValue { get; set; } = true;

                public bool ShouldSerializeTitle()
                {
                        return this.ShouldSerializeTitleValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCreatedValue = false;
                        this.ShouldSerializeEnvironmentIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeProjectIdValue = false;
                        this.ShouldSerializeRelatedDocumentIdsValue = false;
                        this.ShouldSerializeResponsibleTeamIdsValue = false;
                        this.ShouldSerializeStatusValue = false;
                        this.ShouldSerializeTaskIdValue = false;
                        this.ShouldSerializeTenantIdValue = false;
                        this.ShouldSerializeTitleValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>cd90248d799973b99af24636cb4f9f4e</Hash>
</Codenesium>*/