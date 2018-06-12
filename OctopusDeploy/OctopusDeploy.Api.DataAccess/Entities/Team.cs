using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Team", Schema="dbo")]
        public partial class Team:AbstractEntity
        {
                public Team()
                {
                }

                public void SetProperties(
                        string environmentIds,
                        string id,
                        string jSON,
                        string memberUserIds,
                        string name,
                        string projectGroupIds,
                        string projectIds,
                        string tenantIds,
                        string tenantTags)
                {
                        this.EnvironmentIds = environmentIds;
                        this.Id = id;
                        this.JSON = jSON;
                        this.MemberUserIds = memberUserIds;
                        this.Name = name;
                        this.ProjectGroupIds = projectGroupIds;
                        this.ProjectIds = projectIds;
                        this.TenantIds = tenantIds;
                        this.TenantTags = tenantTags;
                }

                [Column("EnvironmentIds", TypeName="nvarchar(-1)")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("MemberUserIds", TypeName="nvarchar(-1)")]
                public string MemberUserIds { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("ProjectGroupIds", TypeName="nvarchar(-1)")]
                public string ProjectGroupIds { get; private set; }

                [Column("ProjectIds", TypeName="nvarchar(-1)")]
                public string ProjectIds { get; private set; }

                [Column("TenantIds", TypeName="nvarchar(-1)")]
                public string TenantIds { get; private set; }

                [Column("TenantTags", TypeName="nvarchar(-1)")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8f4fe3cb83b36c445edcda8c861e8718</Hash>
</Codenesium>*/