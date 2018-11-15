using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostLinkClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime creationDate,
			int linkTypeId,
			int postId,
			int relatedPostId)
		{
			this.Id = id;
			this.CreationDate = creationDate;
			this.LinkTypeId = linkTypeId;
			this.PostId = postId;
			this.RelatedPostId = relatedPostId;
		}

		[JsonProperty]
		public DateTime CreationDate { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkTypeId { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d2a6d2abeeb2490c87334c3852f01aef</Hash>
</Codenesium>*/