using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiVideoServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string description,
			string title,
			string url)
		{
			this.Id = id;
			this.Description = description;
			this.Title = title;
			this.Url = url;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }

		[JsonProperty]
		public string Url { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a1e23dc475d5252e58622470f5d5729b</Hash>
</Codenesium>*/