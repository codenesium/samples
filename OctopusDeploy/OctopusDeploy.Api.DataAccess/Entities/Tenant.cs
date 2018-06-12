using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Tenant", Schema="dbo")]
        public partial class Tenant:AbstractEntity
        {
                public Tenant()
                {
                }

                public void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string name,
                        string projectIds,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectIds = projectIds;
                        this.TenantTags = tenantTags;
                }

                [Column("DataVersion", TypeName="timestamp")]
                public byte[] DataVersion { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("ProjectIds", TypeName="nvarchar(-1)")]
                public string ProjectIds { get; private set; }

                [Column("TenantTags", TypeName="nvarchar(-1)")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6d50e5e5fc1f218b123f3355ebd69677</Hash>
</Codenesium>*/