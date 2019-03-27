using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class ApiSubscriptionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSubscriptionServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string StripePlanName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a7b4827c50c4acdfd047f5cf49884569</Hash>
</Codenesium>*/