using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Pet", Schema="dbo")]
        public partial class Pet : AbstractEntity
        {
                public Pet()
                {
                }

                public virtual void SetProperties(
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
    <Hash>51ad17fe862dff506127ddf7b1e19b3e</Hash>
</Codenesium>*/