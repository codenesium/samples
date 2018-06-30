using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>c02305466c65e611a42e8db37a6256d4</Hash>
</Codenesium>*/