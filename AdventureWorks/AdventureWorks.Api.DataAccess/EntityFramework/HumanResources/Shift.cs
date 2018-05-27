using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Shift", Schema="HumanResources")]
	public partial class Shift:AbstractEntityFrameworkDTO
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
			this.Name = name;
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
    <Hash>2157b8508640d752b6476032e1800afd</Hash>
</Codenesium>*/