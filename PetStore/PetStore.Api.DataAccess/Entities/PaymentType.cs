using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStoreNS.Api.DataAccess
{
        [Table("PaymentType", Schema="dbo")]
        public partial class PaymentType : AbstractEntity
        {
                public PaymentType()
                {
                }

                public void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7da407037bece3f325a91b34a501614b</Hash>
</Codenesium>*/