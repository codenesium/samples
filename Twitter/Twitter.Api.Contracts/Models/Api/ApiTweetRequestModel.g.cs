using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiTweetRequestModel : AbstractApiRequestModel
	{
		public ApiTweetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int locationId,
			TimeSpan time,
			int userUserId)
		{
			this.Content = content;
			this.Date = date;
			this.LocationId = locationId;
			this.Time = time;
			this.UserUserId = userUserId;
		}

		[Required]
		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int LocationId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public int UserUserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>8b656045085af8a15e1f25d5ca843dae</Hash>
</Codenesium>*/