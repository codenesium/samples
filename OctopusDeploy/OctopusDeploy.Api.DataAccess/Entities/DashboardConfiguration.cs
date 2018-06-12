using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("DashboardConfiguration", Schema="dbo")]
        public partial class DashboardConfiguration: AbstractEntity
        {
                public DashboardConfiguration()
                {
                }

                public void SetProperties(
                        string id,
                        string includedEnvironmentIds,
                        string includedProjectIds,
                        string includedTenantIds,
                        string includedTenantTags,
                        string jSON)
                {
                        this.Id = id;
                        this.IncludedEnvironmentIds = includedEnvironmentIds;
                        this.IncludedProjectIds = includedProjectIds;
                        this.IncludedTenantIds = includedTenantIds;
                        this.IncludedTenantTags = includedTenantTags;
                        this.JSON = jSON;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IncludedEnvironmentIds", TypeName="nvarchar(-1)")]
                public string IncludedEnvironmentIds { get; private set; }

                [Column("IncludedProjectIds", TypeName="nvarchar(-1)")]
                public string IncludedProjectIds { get; private set; }

                [Column("IncludedTenantIds", TypeName="nvarchar(-1)")]
                public string IncludedTenantIds { get; private set; }

                [Column("IncludedTenantTags", TypeName="nvarchar(-1)")]
                public string IncludedTenantTags { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8ad7be6b744cd63d2ef2671a6dd3c1fd</Hash>
</Codenesium>*/