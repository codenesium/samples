using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Space", Schema="dbo")]
        public partial class Space:AbstractEntity
        {
                public Space()
                {
                }

                public void SetProperties(
                        string description,
                        int id,
                        string name,
                        int studioId)
                {
                        this.Description = description;
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                [Column("description", TypeName="varchar(128)")]
                public string Description { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(128)")]
                public string Name { get; private set; }

                [Column("studioId", TypeName="int")]
                public int StudioId { get; private set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>c4f4f5c7701945253acedd86eaee5257</Hash>
</Codenesium>*/