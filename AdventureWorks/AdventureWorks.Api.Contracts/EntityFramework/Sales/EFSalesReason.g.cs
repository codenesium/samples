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
    <Hash>7f6430a3e178274719e63d178fe0db38</Hash>
</Codenesium>*/