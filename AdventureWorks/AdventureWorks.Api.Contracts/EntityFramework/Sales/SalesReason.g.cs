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
		public int SalesReasonID {get; set;}
		public string Name {get; set;}
		public string ReasonType {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d14bac3164af59404f4735e31679d079</Hash>
</Codenesium>*/