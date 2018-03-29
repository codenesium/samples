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
		public int ShiftID {get; set;}
		public string Name {get; set;}
		public TimeSpan StartTime {get; set;}
		public TimeSpan EndTime {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>6ec9b15f15a2b95dac18f46f5f8e05b5</Hash>
</Codenesium>*/