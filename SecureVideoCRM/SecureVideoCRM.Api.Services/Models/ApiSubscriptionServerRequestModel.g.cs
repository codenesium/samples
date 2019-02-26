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
			string name)
		{
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>fbe6d970f9e88541a6b3a7087f09f5ca</Hash>
</Codenesium>*/