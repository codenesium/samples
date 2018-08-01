using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProxyRequestModel : AbstractApiRequestModel
	{
		public ApiProxyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string jSON,
			string name)
		{
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ffeb660478d4ce3ddadf1f3db9279d1e</Hash>
</Codenesium>*/