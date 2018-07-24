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
                public virtual Organization OrganizationNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f5c5c672c6f564a29f2bb8d56bb69bb5</Hash>
</Codenesium>*/