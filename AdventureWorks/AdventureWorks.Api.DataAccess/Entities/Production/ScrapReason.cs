using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ScrapReason", Schema="Production")]
        public partial class ScrapReason: AbstractEntity
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

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Key]
                [Column("ScrapReasonID", TypeName="smallint")]
                public short ScrapReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b4baef2b86f12fee84ca427a748fbf15</Hash>
</Codenesium>*/