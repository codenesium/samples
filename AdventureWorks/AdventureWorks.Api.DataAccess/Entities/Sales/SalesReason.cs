using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesReason", Schema="Sales")]
        public partial class SalesReason : AbstractEntity
        {
                public SalesReason()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string reasonType,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                        this.SalesReasonID = salesReasonID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ReasonType")]
                public string ReasonType { get; private set; }

                [Key]
                [Column("SalesReasonID")]
                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ba3be7151eb3825f0d718b9376e8052b</Hash>
</Codenesium>*/