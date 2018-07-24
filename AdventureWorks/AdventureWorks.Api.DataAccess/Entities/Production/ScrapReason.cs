using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ScrapReason", Schema="Production")]
        public partial class ScrapReason : AbstractEntity
        {
                public ScrapReason()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        short scrapReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ScrapReasonID = scrapReasonID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("ScrapReasonID")]
                public short ScrapReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3cba01f4bd2afff1d1bc21cefa83534c</Hash>
</Codenesium>*/