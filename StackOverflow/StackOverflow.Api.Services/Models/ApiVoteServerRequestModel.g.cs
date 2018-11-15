using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiVoteServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVoteServerRequestModel()
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
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

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
    <Hash>1a2320dad72bac0314216882591c9003</Hash>
</Codenesium>*/