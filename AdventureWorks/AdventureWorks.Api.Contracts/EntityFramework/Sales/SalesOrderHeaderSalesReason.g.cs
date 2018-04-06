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

		[ForeignKey("SalesOrderID")]
		public virtual EFSalesOrderHeader SalesOrderHeaderRef { get; set; }
		[ForeignKey("SalesReasonID")]
		public virtual EFSalesReason SalesReasonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>d2aca6a35eaf21e98bfb1e7f254c4472</Hash>
</Codenesium>*/