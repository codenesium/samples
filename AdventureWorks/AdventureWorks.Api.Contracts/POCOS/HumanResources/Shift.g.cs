using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOShift
	{
		public POCOShift()
		{}

		public POCOShift(int shiftID,
		                 string name,
		                 TimeSpan startTime,
		                 TimeSpan endTime,
		                 DateTime modifiedDate)
		{
			this.ShiftID = shiftID;
			this.Name = name;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ShiftID {get; set;}
		public string Name {get; set;}
		public TimeSpan StartTime {get; set;}
		public TimeSpan EndTime {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeShiftIDValue {get; set;} = true;

		public bool ShouldSerializeShiftID()
		{
			return ShouldSerializeShiftIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartTimeValue {get; set;} = true;

		public bool ShouldSerializeStartTime()
		{
			return ShouldSerializeStartTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndTimeValue {get; set;} = true;

		public bool ShouldSerializeEndTime()
		{
			return ShouldSerializeEndTimeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeShiftIDValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeStartTimeValue = false;
			this.ShouldSerializeEndTimeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>733f226600f0efbe46dac2c5c25107a3</Hash>
</Codenesium>*/