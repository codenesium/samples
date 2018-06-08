using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
        [Table("Pen", Schema="dbo")]
        public partial class Pen:AbstractEntity
        {
                public Pen()
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
    <Hash>ce5818dc7be1f0c8c0a9df6fc9c23364</Hash>
</Codenesium>*/