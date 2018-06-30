using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Destination", Schema="dbo")]
        public partial class Destination : AbstractEntity
        {
                public Destination()
                {
                }

                public virtual void SetProperties(
                        int countryId,
                        int id,
                        string name,
                        int order)
                {
                        this.CountryId = countryId;
                        this.Id = id;
                        this.Name = name;
                        this.Order = order;
                }

                [Column("countryId")]
                public int CountryId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("order")]
                public int Order { get; private set; }

                [ForeignKey("CountryId")]
                public virtual Country Country { get; set; }
        }
}

/*<Codenesium>
    <Hash>6154ae5d07295776c88c32986b7d2f41</Hash>
</Codenesium>*/