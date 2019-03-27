using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiVideoClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVideoClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string title,
			string url)
		{
			this.Description = description;
			this.Title = title;
			this.Url = url;
		}

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public string Title { get; private set; } = default(string);

		[JsonProperty]
		public string Url { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a41e6443a59b273f2179445723cd8c32</Hash>
</Codenesium>*/