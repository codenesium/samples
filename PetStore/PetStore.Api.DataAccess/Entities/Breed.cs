using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>39815d37d68fc10cd358697e1ed819b3</Hash>
</Codenesium>*/