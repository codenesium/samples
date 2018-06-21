using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Pet", Schema="dbo")]
        public partial class Pet : AbstractEntity
        {
                public Pet()
                {
                }

                public void SetProperties(
                        int breedId,
                        int clientId,
                        int id,
                        string name,
                        int weight)
                {
                        this.BreedId = breedId;
                        this.ClientId = clientId;
                        this.Id = id;
                        this.Name = name;
                        this.Weight = weight;
                }

                [Column("breedId")]
                public int BreedId { get; private set; }

                [Column("clientId")]
                public int ClientId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("weight")]
                public int Weight { get; private set; }

                [ForeignKey("BreedId")]
                public virtual Breed Breed { get; set; }

                [ForeignKey("ClientId")]
                public virtual Client Client { get; set; }
        }
}

/*<Codenesium>
    <Hash>c9fbe82205a919e41b276d7187133e2a</Hash>
</Codenesium>*/