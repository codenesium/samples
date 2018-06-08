using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Pet", Schema="dbo")]
        public partial class Pet:AbstractEntity
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

                [Column("breedId", TypeName="int")]
                public int BreedId { get; private set; }

                [Column("clientId", TypeName="int")]
                public int ClientId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("weight", TypeName="int")]
                public int Weight { get; private set; }

                [ForeignKey("BreedId")]
                public virtual Breed Breed { get; set; }

                [ForeignKey("ClientId")]
                public virtual Client Client { get; set; }
        }
}

/*<Codenesium>
    <Hash>a795a1b2790c716a4e2301953ec59dcf</Hash>
</Codenesium>*/