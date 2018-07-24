using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Breed", Schema="dbo")]
        public partial class Breed : AbstractEntity
        {
                public Breed()
                {
                }

                public virtual void SetProperties(
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
                public virtual Species SpeciesNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a597776c0ac622ae37732d474827ecf4</Hash>
</Codenesium>*/