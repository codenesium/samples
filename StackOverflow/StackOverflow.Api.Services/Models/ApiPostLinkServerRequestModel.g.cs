using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiPostLinkServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPostLinkServerRequestModel()
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
		public DateTime CreationDate { get; private set; } = SqlDateTime.MinValue.Value;

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
    <Hash>a2434f25cdeba3d9005ba3a91845ac0e</Hash>
</Codenesium>*/