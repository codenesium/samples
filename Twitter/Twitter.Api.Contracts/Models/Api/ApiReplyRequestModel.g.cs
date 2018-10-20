using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiReplyRequestModel : AbstractApiRequestModel
	{
		public ApiReplyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int replierUserId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.ReplierUserId = replierUserId;
			this.Time = time;
		}

		[Required]
		[JsonProperty]
		public string Content { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int ReplierUserId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>be71636b83cfc9e35e31f50a04bf034c</Hash>
</Codenesium>*/