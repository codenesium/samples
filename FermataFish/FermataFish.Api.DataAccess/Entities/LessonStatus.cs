using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("LessonStatus", Schema="dbo")]
        public partial class LessonStatus : AbstractEntity
        {
                public LessonStatus()
                {
                }

                public void SetProperties(
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
    <Hash>8f1adab08504f1ae8a65bbf6a4eadfe5</Hash>
</Codenesium>*/