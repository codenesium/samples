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
		public int LinkTypeId { get; private set; }

		[JsonProperty]
		public int PostId { get; private set; }

		[JsonProperty]
		public int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>29cfa0b890f2d226336fb5daaf5fd91f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/