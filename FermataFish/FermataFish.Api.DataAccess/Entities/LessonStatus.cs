using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>5bdc939e83e2ae720194d6007adb4345</Hash>
</Codenesium>*/