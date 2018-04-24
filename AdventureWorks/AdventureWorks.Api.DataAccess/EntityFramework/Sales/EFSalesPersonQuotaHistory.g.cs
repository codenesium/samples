using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class EFSalesPersonQuotaHistory: AbstractEntityFrameworkPOCO
	{
		public EFSalesPersonQuotaHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime quotaDate,
			decimal salesQuota,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.QuotaDate = quotaDate.ToDateTime();
			this.SalesQuota = salesQuota.ToDecimal();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("QuotaDate", TypeName="datetime")]
		public DateTime QuotaDate { get; set; }

		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFSalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>3009deeb226719c57fda9ebb698285a8</Hash>
</Codenesium>*/