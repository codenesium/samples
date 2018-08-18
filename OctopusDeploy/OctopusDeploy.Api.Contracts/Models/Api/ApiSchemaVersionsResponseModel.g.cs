using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiSchemaVersionsResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime applied,
			string scriptName)
		{
			this.Id = id;
			this.Applied = applied;
			this.ScriptName = scriptName;
		}

		[Required]
		[JsonProperty]
		public DateTime Applied { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string ScriptName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c8ac55dc46a0fee1f5c974c36cd0bde7</Hash>
</Codenesium>*/