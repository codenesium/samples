using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiSubscriptionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSubscriptionClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name)
		{
			this.Name = name;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>fba1be3c6eab6a06080d018d12552cf6</Hash>
</Codenesium>*/