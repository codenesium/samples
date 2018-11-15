using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiTweetServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTweetServerRequestModel()
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
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int LocationId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);

		[Required]
		[JsonProperty]
		public int UserUserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6a6be220e0c4c57e116ac6c6f415c9a4</Hash>
</Codenesium>*/