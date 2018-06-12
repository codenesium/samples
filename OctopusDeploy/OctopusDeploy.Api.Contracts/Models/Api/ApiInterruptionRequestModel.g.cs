using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiInterruptionRequestModel: AbstractApiRequestModel
        {
                public ApiInterruptionRequestModel() : base()
                {
                }

                public void SetProperties(
                        DateTime created,
                        string environmentId,
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
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.ResponsibleTeamIds = responsibleTeamIds;
                        this.Status = status;
                        this.TaskId = taskId;
                        this.TenantId = tenantId;
                        this.Title = title;
                }

                private DateTime created;

                [Required]
                public DateTime Created
                {
                        get
                        {
                                return this.created;
                        }

                        set
                        {
                                this.created = value;
                        }
                }

                private string environmentId;

                [Required]
                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId;
                        }

                        set
                        {
                                this.environmentId = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string projectId;

                [Required]
                public string ProjectId
                {
                        get
                        {
                                return this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
                        }
                }

                private string relatedDocumentIds;

                [Required]
                public string RelatedDocumentIds
                {
                        get
                        {
                                return this.relatedDocumentIds;
                        }

                        set
                        {
                                this.relatedDocumentIds = value;
                        }
                }

                private string responsibleTeamIds;

                [Required]
                public string ResponsibleTeamIds
                {
                        get
                        {
                                return this.responsibleTeamIds;
                        }

                        set
                        {
                                this.responsibleTeamIds = value;
                        }
                }

                private string status;

                [Required]
                public string Status
                {
                        get
                        {
                                return this.status;
                        }

                        set
                        {
                                this.status = value;
                        }
                }

                private string taskId;

                [Required]
                public string TaskId
                {
                        get
                        {
                                return this.taskId;
                        }

                        set
                        {
                                this.taskId = value;
                        }
                }

                private string tenantId;

                public string TenantId
                {
                        get
                        {
                                return this.tenantId.IsEmptyOrZeroOrNull() ? null : this.tenantId;
                        }

                        set
                        {
                                this.tenantId = value;
                        }
                }

                private string title;

                [Required]
                public string Title
                {
                        get
                        {
                                return this.title;
                        }

                        set
                        {
                                this.title = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>47d5df7d923e33e7eb1eba6a5f7d0652</Hash>
</Codenesium>*/