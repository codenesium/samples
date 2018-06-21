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

                public void SetProperties(
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
    <Hash>d9e0e064abfca71bba22ce35ab3e4aa9</Hash>
</Codenesium>*/