using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Team", Schema="dbo")]
        public partial class Team : AbstractEntity
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

                [Column("EnvironmentIds")]
                public string EnvironmentIds { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("MemberUserIds")]
                public string MemberUserIds { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectGroupIds")]
                public string ProjectGroupIds { get; private set; }

                [Column("ProjectIds")]
                public string ProjectIds { get; private set; }

                [Column("TenantIds")]
                public string TenantIds { get; private set; }

                [Column("TenantTags")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>443c01d2c702ac6bb8a13f3096d082c1</Hash>
</Codenesium>*/