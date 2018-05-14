using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Shift", Schema="HumanResources")]
	public partial class Shift:AbstractEntityFrameworkPOCO
	{
		public Shift()
		{}

		public void SetProperties(
			int shiftID,
			TimeSpan endTime,
			DateTime modifiedDate,
			string name,
			TimeSpan startTime)
		{
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ShiftID = shiftID.ToInt();
			this.StartTime = startTime;
		}

		[Column("EndTime", TypeName="time")]
		public TimeSpan EndTime { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ShiftID", TypeName="tinyint")]
		public int ShiftID { get; set; }

		[Column("StartTime", TypeName="time")]
		public TimeSpan StartTime { get; set; }
	}
}

/*<Codenesium>
    <Hash>f2c8eeef26efc417429b4596a0b01558</Hash>
</Codenesium>*/