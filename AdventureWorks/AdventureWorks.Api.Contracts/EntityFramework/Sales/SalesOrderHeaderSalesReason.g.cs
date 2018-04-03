using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class EFSalesOrderHeaderSalesReason
	{
		public EFSalesOrderHeaderSalesReason()
		{}

		[Key]
		public int salesOrderID {get; set;}
		public int salesReasonID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>02a3fc2f5c896d49c5ae2f430cf0ce06</Hash>
</Codenesium>*/