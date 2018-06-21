using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Breed", Schema="dbo")]
        public partial class Breed : AbstractEntity
        {
                public Breed()
                {
                }

                public void SetProperties(
                        int id,
                        string name,
                        int speciesId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.SpeciesId = speciesId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("speciesId")]
                public int SpeciesId { get; private set; }

                [ForeignKey("SpeciesId")]
                public virtual Species Species { get; set; }
        }
}

/*<Codenesium>
    <Hash>d699b49e205aeb70c48b4a0ebb832285</Hash>
</Codenesium>*/