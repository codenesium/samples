using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiVoteRequestModel : AbstractApiRequestModel
	{
		public ApiVoteRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[JsonProperty]
		public int? UserId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int VoteTypeId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>55e1b1fd9ba36136287daed36d9b5d70</Hash>
</Codenesium>*/