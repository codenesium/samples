using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShiftRequestModel : AbstractApiRequestModel
	{
		public ApiShiftRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			TimeSpan endTime,
			DateTime modifiedDate,
			string name,
			TimeSpan startTime)
		{
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.StartTime = startTime;
		}

		[Required]
		[JsonProperty]
		public TimeSpan EndTime { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public TimeSpan StartTime { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>7edd0ecaad65edd53a5f462ef7e142a3</Hash>
</Codenesium>*/