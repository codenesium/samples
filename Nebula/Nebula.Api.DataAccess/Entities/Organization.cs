using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Organization", Schema="dbo")]
        public partial class Organization : AbstractEntity
        {
                public Organization()
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
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b442e7697b00fd34ae257b3ed04f190f</Hash>
</Codenesium>*/