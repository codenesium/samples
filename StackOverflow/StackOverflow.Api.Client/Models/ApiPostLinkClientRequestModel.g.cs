using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostLinkClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostLinkClientRequestModel()
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

		[JsonProperty]
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int LinkTypeId { get; private set; } = default(int);

		[JsonProperty]
		public int PostId { get; private set; } = default(int);

		[JsonProperty]
		public int RelatedPostId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>f1698654ff8a38ee12a880553cbfd4e7</Hash>
</Codenesium>*/