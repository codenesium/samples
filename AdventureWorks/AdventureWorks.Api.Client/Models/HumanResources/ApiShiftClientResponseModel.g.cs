using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShiftClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int shiftID,
			TimeSpan endTime,
			DateTime modifiedDate,
			string name,
			TimeSpan startTime)
		{
			this.ShiftID = shiftID;
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.StartTime = startTime;
		}

		[JsonProperty]
		public TimeSpan EndTime { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ShiftID { get; private set; }

		[JsonProperty]
		public TimeSpan StartTime { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c31d04bc5f58aba0d6ad68c1c0bc82c4</Hash>
</Codenesium>*/