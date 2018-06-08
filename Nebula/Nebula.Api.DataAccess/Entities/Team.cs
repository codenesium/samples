using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
        [Table("Team", Schema="dbo")]
        public partial class Team:AbstractEntity
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
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("organizationId", TypeName="int")]
                public int OrganizationId { get; private set; }

                [ForeignKey("OrganizationId")]
                public virtual Organization Organization { get; set; }
        }
}

/*<Codenesium>
    <Hash>0e16e8417620007b3ef794adad57415d</Hash>
</Codenesium>*/