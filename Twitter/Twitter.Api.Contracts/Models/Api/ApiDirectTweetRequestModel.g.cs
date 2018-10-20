using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiDirectTweetRequestModel : AbstractApiRequestModel
	{
		public ApiDirectTweetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string content,
			DateTime date,
			int taggedUserId,
			TimeSpan time)
		{
			this.Content = content;
			this.Date = date;
			this.TaggedUserId = taggedUserId;
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
		public int TaggedUserId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>98e924d985819d00d68c4bc453aeb0b1</Hash>
</Codenesium>*/