using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesPersonQuotaHistory", Schema="Sales")]
        public partial class SalesPersonQuotaHistory : AbstractEntity
        {
                public SalesPersonQuotaHistory()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        DateTime quotaDate,
                        Guid rowguid,
                        decimal salesQuota)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.QuotaDate = quotaDate;
                        this.Rowguid = rowguid;
                        this.SalesQuota = salesQuota;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("QuotaDate")]
                public DateTime QuotaDate { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesQuota")]
                public decimal SalesQuota { get; private set; }

                [ForeignKey("BusinessEntityID")]
                public virtual SalesPerson SalesPerson { get; set; }
        }
}

/*<Codenesium>
    <Hash>03e06e5b318556f17ab29e5c1102b195</Hash>
</Codenesium>*/