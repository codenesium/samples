using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiEventRequestModel : AbstractApiRequestModel
        {
                public ApiEventRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        long autoId,
                        string category,
                        string environmentId,
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
                        this.JSON = jSON;
                        this.Message = message;
                        this.Occurred = occurred;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                        this.UserId = userId;
                        this.Username = username;
                }

                private long autoId;

                [Required]
                public long AutoId
                {
                        get
                        {
                                return this.autoId;
                        }

                        set
                        {
                                this.autoId = value;
                        }
                }

                private string category;

                [Required]
                public string Category
                {
                        get
                        {
                                return this.category;
                        }

                        set
                        {
                                this.category = value;
                        }
                }

                private string environmentId;

                public string EnvironmentId
                {
                        get
                        {
                                return this.environmentId.IsEmptyOrZeroOrNull() ? null : this.environmentId;
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

                private string message;

                [Required]
                public string Message
                {
                        get
                        {
                                return this.message;
                        }

                        set
                        {
                                this.message = value;
                        }
                }

                private DateTimeOffset occurred;

                [Required]
                public DateTimeOffset Occurred
                {
                        get
                        {
                                return this.occurred;
                        }

                        set
                        {
                                this.occurred = value;
                        }
                }

                private string projectId;

                public string ProjectId
                {
                        get
                        {
                                return this.projectId.IsEmptyOrZeroOrNull() ? null : this.projectId;
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

                private string userId;

                [Required]
                public string UserId
                {
                        get
                        {
                                return this.userId;
                        }

                        set
                        {
                                this.userId = value;
                        }
                }

                private string username;

                [Required]
                public string Username
                {
                        get
                        {
                                return this.username;
                        }

                        set
                        {
                                this.username = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3220450f6a13b754452374a04d10c64d</Hash>
</Codenesium>*/