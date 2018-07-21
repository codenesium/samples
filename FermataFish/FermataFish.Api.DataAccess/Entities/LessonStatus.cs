using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonStatus", Schema="dbo")]
        public partial class LessonStatus : AbstractEntity
        {
                public LessonStatus()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name,
                        int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("Id")]
                public virtual Studio Studio { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>05c0a9b1df47adc33454ed047368120c</Hash>
</Codenesium>*/