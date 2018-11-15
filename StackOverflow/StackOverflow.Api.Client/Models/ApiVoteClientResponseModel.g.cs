using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiVoteClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? bountyAmount,
			DateTime creationDate,
			int postId,
			int? userId,
			int voteTypeId)
		{
			this.Id = id;
			this.BountyAmount = bountyAmount;
			this.CreationDate = creationDate;
			this.PostId = postId;
			this.UserId = userId;
			this.VoteTypeId = voteTypeId;
		}

		[JsonProperty]
		public int? BountyAmount { get; private set; }

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public int? UserId { get; private set; }

		[JsonProperty]
		public int VoteTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6b7b02cf26550fdd5a73284907d7c700</Hash>
</Codenesium>*/