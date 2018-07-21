using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
{
        [Table("Breed", Schema="dbo")]
        public partial class Breed : AbstractEntity
        {
                public Breed()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1e027cdbec56fc3a4dc4eaee31387510</Hash>
</Codenesium>*/