using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Breed", Schema="dbo")]
        public partial class Breed:AbstractEntity
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("speciesId", TypeName="int")]
                public int SpeciesId { get; private set; }

                [ForeignKey("SpeciesId")]
                public virtual Species Species { get; set; }
        }
}

/*<Codenesium>
    <Hash>5b2de627eb9e97c518c72edf0ac507bd</Hash>
</Codenesium>*/