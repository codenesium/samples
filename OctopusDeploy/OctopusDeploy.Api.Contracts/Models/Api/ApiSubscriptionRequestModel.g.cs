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
    <Hash>6a86e3dc7a40509834d58089747964cd</Hash>
</Codenesium>*/