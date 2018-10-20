using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
	public partial class ApiPostLinkRequestModel : AbstractApiRequestModel
	{
		public ApiPostLinkRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime creationDate,
			int linkTypeId,
			int postId,
			int relatedPostId)
		{
			this.CreationDate = creationDate;
			this.LinkTypeId = linkTypeId;
			this.PostId = postId;
			this.RelatedPostId = relatedPostId;
		}

		[Required]
		[JsonProperty]
		public DateTime CreationDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int LinkTypeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int RelatedPostId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>2221202879b35381da293a6eb63d069b</Hash>
</Codenesium>*/