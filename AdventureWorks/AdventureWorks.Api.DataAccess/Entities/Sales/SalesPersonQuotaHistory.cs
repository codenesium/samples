using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesPersonQuotaHistory", Schema="Sales")]
        public partial class SalesPersonQuotaHistory : AbstractEntity
        {
                public SalesPersonQuotaHistory()
                {
                }

                public virtual void SetProperties(
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

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("SalesQuota")]
                public decimal SalesQuota { get; private set; }

                [ForeignKey("BusinessEntityID")]
                public virtual SalesPerson SalesPersonNavigation { get; private set; }
        }
}

/*<Codenesium>
    <Hash>30a5124b6a95901beeee4d468f9622d7</Hash>
</Codenesium>*/