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
		public string Content { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; }

		[Required]
		[JsonProperty]
		public int LocationId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; }

		[Required]
		[JsonProperty]
		public int UserUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>65945973e7cb5dd93c7543a47b342bd0</Hash>
</Codenesium>*/