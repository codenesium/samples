using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("WorkerPool", Schema="dbo")]
        public partial class WorkerPool: AbstractEntity
        {
                public WorkerPool()
                {
                }

                public void SetProperties(
                        string id,
                        bool isDefault,
                        string jSON,
                        string name,
                        int sortOrder)
                {
                        this.Id = id;
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                        this.SortOrder = sortOrder;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDefault", TypeName="bit")]
                public bool IsDefault { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("SortOrder", TypeName="int")]
                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fb50341ace99edfc79c4a53bb6926971</Hash>
</Codenesium>*/