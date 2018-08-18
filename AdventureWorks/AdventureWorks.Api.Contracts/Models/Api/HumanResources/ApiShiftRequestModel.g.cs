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
		public TimeSpan EndTime { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan StartTime { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dac3226a521e316880efc62a8df3ef3c</Hash>
</Codenesium>*/