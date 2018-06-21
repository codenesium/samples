using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Channel", Schema="dbo")]
        public partial class Channel : AbstractEntity
        {
                public Channel()
                {
                }

                public void SetProperties(
                        byte[] dataVersion,
                        string id,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectId,
                        string tenantTags)
                {
                        this.DataVersion = dataVersion;
                        this.Id = id;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TenantTags = tenantTags;
                }

                [Column("DataVersion")]
                public byte[] DataVersion { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("LifecycleId")]
                public string LifecycleId { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("TenantTags")]
                public string TenantTags { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c032fa57e73c2c7b5369813a7acf1308</Hash>
</Codenesium>*/