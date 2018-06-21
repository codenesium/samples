using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Team", Schema="dbo")]
        public partial class Team : AbstractEntity
        {
                public Team()
                {
                }

                public void SetProperties(
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
    <Hash>510963441b02207084c89e67097f89cb</Hash>
</Codenesium>*/