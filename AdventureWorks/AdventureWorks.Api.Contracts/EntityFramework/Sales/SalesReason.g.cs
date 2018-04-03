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
		public int salesReasonID {get; set;}
		public string name {get; set;}
		public string reasonType {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>782b35e02a40e6d6a43387f0ec4c2bad</Hash>
</Codenesium>*/