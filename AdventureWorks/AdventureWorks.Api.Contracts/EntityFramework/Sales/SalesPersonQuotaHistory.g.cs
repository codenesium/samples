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
		public int businessEntityID {get; set;}
		public DateTime quotaDate {get; set;}
		public decimal salesQuota {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>0f9560554892f45fd0c64068fde16c7f</Hash>
</Codenesium>*/