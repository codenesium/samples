using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("KeyAllocation", Schema="dbo")]
        public partial class KeyAllocation : AbstractEntity
        {
                public KeyAllocation()
                {
                }

                public virtual void SetProperties(
                        int allocated,
                        string collectionName)
                {
                        this.Allocated = allocated;
                        this.CollectionName = collectionName;
                }

                [Column("Allocated")]
                public int Allocated { get; private set; }

                [Key]
                [Column("CollectionName")]
                public string CollectionName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b3ed1142c09bf207b3cfdb354f7e43b0</Hash>
</Codenesium>*/