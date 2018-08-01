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
    <Hash>effd7f905e0f99a4d8d5f0b348011f32</Hash>
</Codenesium>*/