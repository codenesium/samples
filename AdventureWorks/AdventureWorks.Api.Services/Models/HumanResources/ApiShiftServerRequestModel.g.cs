using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiShiftServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiShiftServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public TimeSpan StartTime { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>89d14c094a54e32272b0d682c7d565bb</Hash>
</Codenesium>*/