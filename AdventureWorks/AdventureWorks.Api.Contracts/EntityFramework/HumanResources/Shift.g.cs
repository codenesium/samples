using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Shift", Schema="HumanResources")]
	public partial class EFShift
	{
		public EFShift()
		{}

		[Key]
		public int shiftID {get; set;}
		public string name {get; set;}
		public TimeSpan startTime {get; set;}
		public TimeSpan endTime {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>451486c825862ede4500b5cbd67b3a9f</Hash>
</Codenesium>*/