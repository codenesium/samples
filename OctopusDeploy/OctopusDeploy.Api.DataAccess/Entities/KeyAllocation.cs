using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>01e8a35db0174cb763d9bd14933aa669</Hash>
</Codenesium>*/