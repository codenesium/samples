using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiMachinePolicyRequestModel : AbstractApiRequestModel
	{
		public ApiMachinePolicyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isDefault,
			string jSON,
			string name)
		{
			this.IsDefault = isDefault;
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public bool IsDefault { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad592a2581a35e137978f71b38931714</Hash>
</Codenesium>*/