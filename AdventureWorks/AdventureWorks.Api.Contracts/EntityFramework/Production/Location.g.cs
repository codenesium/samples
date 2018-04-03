using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Location", Schema="Production")]
	public partial class EFLocation
	{
		public EFLocation()
		{}

		[Key]
		public short locationID {get; set;}
		public string name {get; set;}
		public decimal costRate {get; set;}
		public decimal availability {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>0ace5d29666d49997677ff9f616dd98a</Hash>
</Codenesium>*/