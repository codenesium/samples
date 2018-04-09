using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class EFSalesPersonQuotaHistory
	{
		public EFSalesPersonQuotaHistory()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime quotaDate,
		                          decimal salesQuota,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.QuotaDate = quotaDate.ToDateTime();
			this.SalesQuota = salesQuota;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("QuotaDate", TypeName="datetime")]
		public DateTime QuotaDate {get; set;}

		[Column("SalesQuota", TypeName="money")]
		public decimal SalesQuota {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFSalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>0a745df9b7054018f64ec25dce411858</Hash>
</Codenesium>*/