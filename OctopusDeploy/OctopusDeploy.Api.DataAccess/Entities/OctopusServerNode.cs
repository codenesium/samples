using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("OctopusServerNode", Schema="dbo")]
        public partial class OctopusServerNode: AbstractEntity
        {
                public OctopusServerNode()
                {
                }

                public void SetProperties(
                        string id,
                        bool isInMaintenanceMode,
                        string jSON,
                        DateTime lastSeen,
                        int maxConcurrentTasks,
                        string name,
                        string rank)
                {
                        this.Id = id;
                        this.IsInMaintenanceMode = isInMaintenanceMode;
                        this.JSON = jSON;
                        this.LastSeen = lastSeen;
                        this.MaxConcurrentTasks = maxConcurrentTasks;
                        this.Name = name;
                        this.Rank = rank;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(250)")]
                public string Id { get; private set; }

                [Column("IsInMaintenanceMode", TypeName="bit")]
                public bool IsInMaintenanceMode { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("LastSeen", TypeName="datetimeoffset")]
                public DateTime LastSeen { get; private set; }

                [Column("MaxConcurrentTasks", TypeName="int")]
                public int MaxConcurrentTasks { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("Rank", TypeName="nvarchar(50)")]
                public string Rank { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a8097ff79c1e0fdc267e7d8fc24d5cbe</Hash>
</Codenesium>*/