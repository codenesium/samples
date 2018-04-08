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
		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }
		[ForeignKey("SalesReasonID")]
		public virtual EFSalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>c25e5a797eae4c1fe8f1a4195d13da74</Hash>
</Codenesium>*/