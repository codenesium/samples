using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiCommentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime creationDate,
			int postId,
			int? score,
			string text,
			int? userId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.Score = score;
			this.Text = text;
			this.UserId = userId;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public int? Score { get; private set; }

		[JsonProperty]
		public string Text { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7bffe1d7a6e420acc024acf90ad41b2e</Hash>
</Codenesium>*/