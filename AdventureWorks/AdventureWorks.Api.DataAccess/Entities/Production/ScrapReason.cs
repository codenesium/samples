using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ScrapReason", Schema="Production")]
        public partial class ScrapReason : AbstractEntity
        {
                public ScrapReason()
                {
                }

                public void SetProperties(
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
                [Column("ScrapReasonID")]
                public short ScrapReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a388fa32519f83b2f8bc585b4f036e36</Hash>
</Codenesium>*/