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
		public int LinkTypeId { get; private set; }

		[Required]
		[JsonProperty]
		public int PostId { get; private set; }

		[Required]
		[JsonProperty]
		public int RelatedPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>90b99164696418174a508290d264efc0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/