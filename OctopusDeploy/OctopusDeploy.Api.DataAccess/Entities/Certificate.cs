using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Certificate", Schema="dbo")]
        public partial class Certificate: AbstractEntity
        {
                public Certificate()
                {
                }

                public void SetProperties(
                        Nullable<DateTimeOffset> archived,
                        DateTimeOffset created,
                        byte[] dataVersion,
                        string environmentIds,
                        string id,
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
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.NotAfter = notAfter;
                        this.Subject = subject;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                        this.Thumbprint = thumbprint;
                }

                [Column("Archived", TypeName="datetimeoffset")]
                public Nullable<DateTimeOffset> Archived { get; private set; }

                [Column("Created", TypeName="datetimeoffset")]
                public DateTimeOffset Created { get; private set; }

                [Column("DataVersion", TypeName="timestamp")]
                public byte[] DataVersion { get; private set; }

                [Column("EnvironmentIds", TypeName="nvarchar(-1)")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id", TypeName="varchar(210)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("NotAfter", TypeName="datetimeoffset")]
                public DateTimeOffset NotAfter { get; private set; }

                [Column("Subject", TypeName="nvarchar(-1)")]
                public string Subject { get; private set; }

                [Column("TenantIds", TypeName="nvarchar(-1)")]
                public string TenantIds { get; private set; }

                [Column("TenantTags", TypeName="nvarchar(-1)")]
                public string TenantTags { get; private set; }

                [Column("Thumbprint", TypeName="nvarchar(128)")]
                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>447c9bdad907c153d32b4cea9a8b897e</Hash>
</Codenesium>*/