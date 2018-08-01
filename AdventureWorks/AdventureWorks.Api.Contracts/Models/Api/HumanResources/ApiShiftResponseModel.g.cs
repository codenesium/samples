using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShiftResponseModel : AbstractApiResponseModel
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
    <Hash>94c68fb81f605bf820104437d1694825</Hash>
</Codenesium>*/