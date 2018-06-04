using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class SalesPersonQuotaHistory: AbstractEntity
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
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("QuotaDate", TypeName="datetime")]
		public DateTime QuotaDate { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>9e830fd6645a6482747c58d3d56ec9ff</Hash>
</Codenesium>*/