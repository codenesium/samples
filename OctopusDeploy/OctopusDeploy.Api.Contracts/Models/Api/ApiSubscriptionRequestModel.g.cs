using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiSubscriptionRequestModel : AbstractApiRequestModel
	{
		public ApiSubscriptionRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isDisabled,
			string jSON,
			string name,
			string type)
		{
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.Name = name;
			this.Type = type;
		}

		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bb8f1f16eb8c50a71a18ad56c38a9210</Hash>
</Codenesium>*/