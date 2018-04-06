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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShiftID", TypeName="tinyint")]
		public int ShiftID {get; set;}
		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}
		[Column("StartTime", TypeName="time")]
		public TimeSpan StartTime {get; set;}
		[Column("EndTime", TypeName="time")]
		public TimeSpan EndTime {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>96e3870359193a36bf99cf943ff85550</Hash>
</Codenesium>*/