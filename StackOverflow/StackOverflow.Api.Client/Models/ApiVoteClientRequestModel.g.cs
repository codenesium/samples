using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiVoteClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVoteClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? bountyAmount,
			DateTime creationDate,
			int postId,
			int? userId,
			int voteTypeId)
		{
			this.BountyAmount = bountyAmount;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.UserId = userId;
			this.VoteTypeId = voteTypeId;
		}

		[JsonProperty]
		public int? BountyAmount { get; private set; } = default(int);

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);

		[JsonProperty]
		public int VoteTypeId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>08453ca9025a23a2adf91d8f77d266ff</Hash>
</Codenesium>*/