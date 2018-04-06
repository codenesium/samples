using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesReason", Schema="Sales")]
	public partial class EFSalesReason
	{
		public EFSalesReason()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("ReasonType", TypeName="nvarchar(50)")]
		public string ReasonType {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>805f4ab229297ff159463d07c7106252</Hash>
</Codenesium>*/