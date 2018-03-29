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
		public int SalesOrderID {get; set;}
		public int SalesReasonID {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("SalesOrderID")]
		public virtual EFSalesOrderHeader SalesOrderHeaderRef { get; set; }
		[ForeignKey("SalesReasonID")]
		public virtual EFSalesReason SalesReasonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>2b3f350ec237102c74400d3ecf17d61a</Hash>
</Codenesium>*/