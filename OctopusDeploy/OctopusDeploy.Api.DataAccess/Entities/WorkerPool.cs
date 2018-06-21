using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("WorkerPool", Schema="dbo")]
        public partial class WorkerPool : AbstractEntity
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
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsDefault")]
                public bool IsDefault { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("SortOrder")]
                public int SortOrder { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b7b46651091501e8445cb6cc2c292c2a</Hash>
</Codenesium>*/