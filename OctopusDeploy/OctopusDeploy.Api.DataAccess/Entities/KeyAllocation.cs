using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
    <Hash>09783462aeee01496b6df07a4ac01537</Hash>
</Codenesium>*/