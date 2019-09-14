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
			string name,
			string stripePlanName)
		{
			this.Name = name;
			this.StripePlanName = stripePlanName;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string StripePlanName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>1fd4cf453f3942e676c964a8e95db4f8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/