using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class EFSalesPersonQuotaHistory
	{
		public EFSalesPersonQuotaHistory()
		{}

		[Key]
		public int BusinessEntityID {get; set;}
		public DateTime QuotaDate {get; set;}
		public decimal SalesQuota {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>e34403697a6c823d3955ca33f6a5c291</Hash>
</Codenesium>*/