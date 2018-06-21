using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FermataFishNS.Api.DataAccess
{
        [Table("Family", Schema="dbo")]
        public partial class Family : AbstractEntity
        {
                public Family()
                {
                }

                public void SetProperties(
                        int id,
                        string notes,
                        string pcEmail,
                        string pcFirstName,
                        string pcLastName,
                        string pcPhone,
                        int studioId)
                {
                        this.Id = id;
                        this.Notes = notes;
                        this.PcEmail = pcEmail;
                        this.PcFirstName = pcFirstName;
                        this.PcLastName = pcLastName;
                        this.PcPhone = pcPhone;
                        this.StudioId = studioId;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("notes")]
                public string Notes { get; private set; }

                [Column("pcEmail")]
                public string PcEmail { get; private set; }

                [Column("pcFirstName")]
                public string PcFirstName { get; private set; }

                [Column("pcLastName")]
                public string PcLastName { get; private set; }

                [Column("pcPhone")]
                public string PcPhone { get; private set; }

                [Column("studioId")]
                public int StudioId { get; private set; }

                [ForeignKey("Id")]
                public virtual Studio Studio { get; set; }

                [ForeignKey("StudioId")]
                public virtual Studio Studio1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>d5810dc33c460e9a97ed3597c06b1eb7</Hash>
</Codenesium>*/