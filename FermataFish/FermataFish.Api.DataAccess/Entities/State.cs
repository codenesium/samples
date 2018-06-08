using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("State", Schema="dbo")]
        public partial class State:AbstractEntity
        {
                public State()
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

                [Column("name", TypeName="varchar(2)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d7428d466f94062b20327290e621e3b5</Hash>
</Codenesium>*/