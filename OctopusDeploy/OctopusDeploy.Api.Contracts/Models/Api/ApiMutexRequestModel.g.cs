using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiMutexRequestModel : AbstractApiRequestModel
	{
		public ApiMutexRequestModel()
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
    <Hash>b707d899092c4aaf3237d3e49fe60569</Hash>
</Codenesium>*/