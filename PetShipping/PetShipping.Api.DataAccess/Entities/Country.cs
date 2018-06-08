using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
        [Table("Country", Schema="dbo")]
        public partial class Country: AbstractEntity
        {
                public Country()
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>394464a20127e3d73e86a98d3d15c4eb</Hash>
</Codenesium>*/