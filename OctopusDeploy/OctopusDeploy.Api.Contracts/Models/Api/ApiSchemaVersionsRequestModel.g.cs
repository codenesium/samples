using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiSchemaVersionsRequestModel : AbstractApiRequestModel
	{
		public ApiSchemaVersionsRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime applied,
			string scriptName)
		{
			this.Applied = applied;
			this.ScriptName = scriptName;
		}

		[JsonProperty]
		public DateTime Applied { get; private set; }

		[JsonProperty]
		public string ScriptName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9833e0ba9bd573addc1de2957ff61d3a</Hash>
</Codenesium>*/