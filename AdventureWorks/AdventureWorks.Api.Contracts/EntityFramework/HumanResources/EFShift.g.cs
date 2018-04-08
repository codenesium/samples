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
    <Hash>42f0c54efe0c962fa294c265e44efd32</Hash>
</Codenesium>*/