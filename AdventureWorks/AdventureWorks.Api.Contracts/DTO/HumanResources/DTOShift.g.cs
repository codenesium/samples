using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOShift: AbstractDTO
	{
		public DTOShift() : base()
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

		public TimeSpan EndTime { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ShiftID { get; set; }
		public TimeSpan StartTime { get; set; }
	}
}

/*<Codenesium>
    <Hash>a8d09dda55b1f752ce3a87a8c2974731</Hash>
</Codenesium>*/