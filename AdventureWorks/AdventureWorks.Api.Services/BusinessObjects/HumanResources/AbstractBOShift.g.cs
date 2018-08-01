using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOShift : AbstractBusinessObject
	{
		public AbstractBOShift()
			: base()
		{
		}

		public virtual void SetProperties(int shiftID,
		                                  TimeSpan endTime,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  TimeSpan startTime)
		{
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ShiftID = shiftID;
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
    <Hash>fb0202e61543e86f13a126c6af720212</Hash>
</Codenesium>*/