using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
	public partial class ApiTagServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int count,
			int excerptPostId,
			string tagName,
			int wikiPostId)
		{
			this.Id = id;
			this.Count = count;
			this.ExcerptPostId = excerptPostId;
			this.TagName = tagName;
			this.WikiPostId = wikiPostId;
		}

		[JsonProperty]
		public int Count { get; private set; }

		[JsonProperty]
		public int ExcerptPostId { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string TagName { get; private set; }

		[JsonProperty]
		public int WikiPostId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>df9c0e4f88dacecfdab5dac068215c13</Hash>
</Codenesium>*/