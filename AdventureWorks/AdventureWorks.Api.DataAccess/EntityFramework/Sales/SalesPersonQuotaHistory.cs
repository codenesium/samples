using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class SalesPersonQuotaHistory: AbstractEntityFrameworkDTO
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

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>dd32a31c4164571631ed6dc2182cc0e3</Hash>
</Codenesium>*/