using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiLifecycleRequestModel : AbstractApiRequestModel
	{
		public ApiLifecycleRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string jSON,
			string name)
		{
			this.DataVersion = dataVersion;
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d1ab0aa36ee32af2cd3871805c3f90fb</Hash>
</Codenesium>*/