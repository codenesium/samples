using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiVotesResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int? BountyAmount { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int PostId { get; private set; }

		[Required]
		[JsonProperty]
		public int? UserId { get; private set; }

		[Required]
		[JsonProperty]
		public int VoteTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a258f8b66c38a3c3b2fdf3b4e93f416d</Hash>
</Codenesium>*/