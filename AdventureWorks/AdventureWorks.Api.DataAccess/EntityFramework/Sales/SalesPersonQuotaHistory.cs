using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class SalesPersonQuotaHistory: AbstractEntityFrameworkPOCO
	{
		public SalesPersonQuotaHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.QuotaDate = quotaDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SalesQuota = salesQuota.ToDecimal();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("QuotaDate", TypeName="datetime")]
		public DateTime QuotaDate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>7653b5990af3ff351cb595bd8d976ec0</Hash>
</Codenesium>*/