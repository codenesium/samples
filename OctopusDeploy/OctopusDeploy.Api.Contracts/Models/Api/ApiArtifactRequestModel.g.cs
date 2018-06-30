using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiArtifactRequestModel : AbstractApiRequestModel
        {
                public ApiArtifactRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTimeOffset created,
                        string environmentId,
                        string filename,
                        string jSON,
                        string projectId,
                        string relatedDocumentIds,
                        string tenantId)
                {
                        this.Created = created;
                        this.EnvironmentId = environmentId;
                        this.Filename = filename;
                        this.JSON = jSON;
                        this.ProjectId = projectId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.TenantId = tenantId;
                }

                private DateTimeOffset created;

                [Required]
                public DateTimeOffset Created
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

                private string filename;

                [Required]
                public string Filename
                {
                        get
                        {
                                return this.filename;
                        }

                        set
                        {
                                this.filename = value;
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

                private string tenantId;

                public string TenantId
                {
                        get
                        {
                                return this.tenantId;
                        }

                        set
                        {
                                this.tenantId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4a3bfac925178984a1ad5c7ed53a002f</Hash>
</Codenesium>*/