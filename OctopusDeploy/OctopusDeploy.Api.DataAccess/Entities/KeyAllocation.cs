using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("KeyAllocation", Schema="dbo")]
        public partial class KeyAllocation: AbstractEntity
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

                [Column("Allocated", TypeName="int")]
                public int Allocated { get; private set; }

                [Key]
                [Column("CollectionName", TypeName="nvarchar(50)")]
                public string CollectionName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>97bc995d89d277f522d35733dca224e2</Hash>
</Codenesium>*/