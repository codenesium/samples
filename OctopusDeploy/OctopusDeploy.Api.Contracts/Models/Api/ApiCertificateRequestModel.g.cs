using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCertificateRequestModel : AbstractApiRequestModel
        {
                public ApiCertificateRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTimeOffset> archived,
                        DateTimeOffset created,
                        byte[] dataVersion,
                        string environmentIds,
                        string jSON,
                        string name,
                        DateTimeOffset notAfter,
                        string subject,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.Archived = archived;
                        this.Created = created;
                        this.DataVersion = dataVersion;
                        this.EnvironmentIds = environmentIds;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                private Nullable<DateTimeOffset> archived;

                public Nullable<DateTimeOffset> Archived
                {
                        get
                        {
                                return this.archived.IsEmptyOrZeroOrNull() ? null : this.archived;
                        }

                        set
                        {
                                this.archived = value;
                        }
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

                private byte[] dataVersion;

                [Required]
                public byte[] DataVersion
                {
                        get
                        {
                                return this.dataVersion;
                        }

                        set
                        {
                                this.dataVersion = value;
                        }
                }

                private string environmentIds;

                public string EnvironmentIds
                {
                        get
                        {
                                return this.environmentIds.IsEmptyOrZeroOrNull() ? null : this.environmentIds;
                        }

                        set
                        {
                                this.environmentIds = value;
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private DateTimeOffset notAfter;

                [Required]
                public DateTimeOffset NotAfter
                {
                        get
                        {
                                return this.notAfter;
                        }

                        set
                        {
                                this.notAfter = value;
                        }
                }

                private string subject;

                [Required]
                public string Subject
                {
                        get
                        {
                                return this.subject;
                        }

                        set
                        {
                                this.subject = value;
                        }
                }

                private string tenantIds;

                public string TenantIds
                {
                        get
                        {
                                return this.tenantIds.IsEmptyOrZeroOrNull() ? null : this.tenantIds;
                        }

                        set
                        {
                                this.tenantIds = value;
                        }
                }

                private string tenantTags;

                public string TenantTags
                {
                        get
                        {
                                return this.tenantTags.IsEmptyOrZeroOrNull() ? null : this.tenantTags;
                        }

                        set
                        {
                                this.tenantTags = value;
                        }
                }

                private string thumbprint;

                [Required]
                public string Thumbprint
                {
                        get
                        {
                                return this.thumbprint;
                        }

                        set
                        {
                                this.thumbprint = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>3f3a155865ef96b162b2d86e9416ba25</Hash>
</Codenesium>*/