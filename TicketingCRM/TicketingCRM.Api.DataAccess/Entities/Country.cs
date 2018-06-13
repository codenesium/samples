using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>a3f7c8bd5f6bb011ccf110c8efd8642f</Hash>
</Codenesium>*/