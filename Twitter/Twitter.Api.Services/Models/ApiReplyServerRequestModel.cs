using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiReplyServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiReplyServerRequestModel()
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
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int ReplierUserId { get; private set; }

		[Required]
		[JsonProperty]
		public TimeSpan Time { get; private set; } = default(TimeSpan);
	}
}

/*<Codenesium>
    <Hash>35d618b9be6ba5e8df1f4175a98cde47</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/