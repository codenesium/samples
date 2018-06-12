using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Machine", Schema="dbo")]
        public partial class Machine: AbstractEntity
        {
                public Machine()
                {
                }

                public void SetProperties(
                        string communicationStyle,
                        string environmentIds,
                        string fingerprint,
                        string id,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string roles,
                        string tenantIds,
                        string tenantTags,
                        string thumbprint)
                {
                        this.CommunicationStyle = communicationStyle;
                        this.EnvironmentIds = environmentIds;
                        this.Fingerprint = fingerprint;
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Roles = roles;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                [Column("CommunicationStyle", TypeName="nvarchar(50)")]
                public string CommunicationStyle { get; private set; }

                [Column("EnvironmentIds", TypeName="nvarchar(-1)")]
                public string EnvironmentIds { get; private set; }

                [Column("Fingerprint", TypeName="nvarchar(50)")]
                public string Fingerprint { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDisabled", TypeName="bit")]
                public bool IsDisabled { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("MachinePolicyId", TypeName="nvarchar(50)")]
                public string MachinePolicyId { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("RelatedDocumentIds", TypeName="nvarchar(-1)")]
                public string RelatedDocumentIds { get; private set; }

                [Column("Roles", TypeName="nvarchar(-1)")]
                public string Roles { get; private set; }

                [Column("TenantIds", TypeName="nvarchar(-1)")]
                public string TenantIds { get; private set; }

                [Column("TenantTags", TypeName="nvarchar(-1)")]
                public string TenantTags { get; private set; }

                [Column("Thumbprint", TypeName="nvarchar(50)")]
                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8e4da1158f02deb6e16c6e41b0defa66</Hash>
</Codenesium>*/