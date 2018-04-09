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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID {get; set;}

		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }

		public virtual EFSalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>a9c82f2949583a62c8f4d7d1e0321768</Hash>
</Codenesium>*/