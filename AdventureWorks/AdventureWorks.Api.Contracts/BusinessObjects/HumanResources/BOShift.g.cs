using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOShift: AbstractBusinessObject
	{
		public BOShift() : base()
		{}

		public void SetProperties(int shiftID,
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

		public TimeSpan EndTime { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int ShiftID { get; private set; }
		public TimeSpan StartTime { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a0591d5433db6309462fb216148b1510</Hash>
</Codenesium>*/