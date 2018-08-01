using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiConfigurationRequestModel : AbstractApiRequestModel
	{
		public ApiConfigurationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string jSON)
		{
			this.JSON = jSON;
		}

		[JsonProperty]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>eae348165507bdcafe08cd101de58ba7</Hash>
</Codenesium>*/