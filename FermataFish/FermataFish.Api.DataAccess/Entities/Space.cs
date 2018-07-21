using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Space", Schema="dbo")]
        public partial class Space : AbstractEntity
        {
                public Space()
                {
                }

                public virtual void SetProperties(
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

                [Column("description")]
                public string Description { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio { get; set; }
        }
}

/*<Codenesium>
    <Hash>6b278daa1a07092110e0f95ecaea66cc</Hash>
</Codenesium>*/