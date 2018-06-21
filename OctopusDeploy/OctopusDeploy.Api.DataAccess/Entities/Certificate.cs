using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Certificate", Schema="dbo")]
        public partial class Certificate : AbstractEntity
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

                [Column("Archived")]
                public Nullable<DateTimeOffset> Archived { get; private set; }

                [Column("Created")]
                public DateTimeOffset Created { get; private set; }

                [Column("DataVersion")]
                public byte[] DataVersion { get; private set; }

                [Column("EnvironmentIds")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("NotAfter")]
                public DateTimeOffset NotAfter { get; private set; }

                [Column("Subject")]
                public string Subject { get; private set; }

                [Column("TenantIds")]
                public string TenantIds { get; private set; }

                [Column("TenantTags")]
                public string TenantTags { get; private set; }

                [Column("Thumbprint")]
                public string Thumbprint { get; private set; }
        }
}

/*<Codenesium>
    <Hash>753c6ef528edfaeb2bc03f98d34142a2</Hash>
</Codenesium>*/