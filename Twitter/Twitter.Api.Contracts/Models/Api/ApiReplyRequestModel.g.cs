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
		public string Content { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; }

		[Required]
		[JsonProperty]
		public int ReplierUserId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c81a898475bf74029ec10694af7095e1</Hash>
</Codenesium>*/