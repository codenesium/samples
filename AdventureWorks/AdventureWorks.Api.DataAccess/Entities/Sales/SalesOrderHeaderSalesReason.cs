using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
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
    <Hash>e9051a3f8dbbe1716bca2ca565fa6d15</Hash>
</Codenesium>*/