using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesOrderHeaderSalesReason", Schema="Sales")]
        public partial class SalesOrderHeaderSalesReason : AbstractEntity
        {
                public SalesOrderHeaderSalesReason()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        int salesOrderID,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.SalesOrderID = salesOrderID;
                        this.SalesReasonID = salesReasonID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("SalesOrderID")]
                public int SalesOrderID { get; private set; }

                [Column("SalesReasonID")]
                public int SalesReasonID { get; private set; }

                [ForeignKey("SalesOrderID")]
                public virtual SalesOrderHeader SalesOrderHeader { get; set; }

                [ForeignKey("SalesReasonID")]
                public virtual SalesReason SalesReason { get; set; }
        }
}

/*<Codenesium>
    <Hash>5f0710e5a722c0a06dd4842bfc5c603a</Hash>
</Codenesium>*/