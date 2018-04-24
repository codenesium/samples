using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Shift", Schema="HumanResources")]
	public partial class EFShift: AbstractEntityFrameworkPOCO
	{
		public EFShift()
		{}

		public void SetProperties(
			int shiftID,
			string name,
			TimeSpan startTime,
			TimeSpan endTime,
			DateTime modifiedDate)
		{
			this.ShiftID = shiftID.ToInt();
			this.Name = name.ToString();
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ShiftID", TypeName="tinyint")]
		public int ShiftID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("StartTime", TypeName="time")]
		public TimeSpan StartTime { get; set; }

		[Column("EndTime", TypeName="time")]
		public TimeSpan EndTime { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>430f5b8856666129a1f0b3dd8f9c5a51</Hash>
</Codenesium>*/