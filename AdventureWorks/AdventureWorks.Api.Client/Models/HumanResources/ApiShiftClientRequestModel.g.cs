using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShiftClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiShiftClientRequestModel()
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

		[JsonProperty]
		public TimeSpan EndTime { get; private set; } = default(TimeSpan);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public TimeSpan StartTime { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>b9430feaf7bd936b37acc23d46f3fefa</Hash>
</Codenesium>*/