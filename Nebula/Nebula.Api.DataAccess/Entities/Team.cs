using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
        [Table("Team", Schema="dbo")]
        public partial class Team : AbstractEntity
        {
                public Team()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name,
                        int organizationId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.OrganizationId = organizationId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("organizationId")]
                public int OrganizationId { get; private set; }

                [ForeignKey("OrganizationId")]
                public virtual Organization Organization { get; set; }
        }
}

/*<Codenesium>
    <Hash>4c7c3fe5c48b2b0d94a1bb04988831ed</Hash>
</Codenesium>*/