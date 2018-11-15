using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiCommentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCommentClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime creationDate,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[JsonProperty]
		public int? Score { get; private set; } = default(int);

		[JsonProperty]
		public string Text { get; private set; } = default(string);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>606fdfd5fd469a51640c1d76669374d0</Hash>
</Codenesium>*/