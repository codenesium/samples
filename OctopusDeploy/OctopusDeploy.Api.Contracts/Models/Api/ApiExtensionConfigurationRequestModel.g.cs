using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiExtensionConfigurationRequestModel : AbstractApiRequestModel
	{
		public ApiExtensionConfigurationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string extensionAuthor,
			string jSON,
			string name)
		{
			this.ExtensionAuthor = extensionAuthor;
			this.JSON = jSON;
			this.Name = name;
		}

		[JsonProperty]
		public string ExtensionAuthor { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ab0500ceaa6c8148a55456c938a769a8</Hash>
</Codenesium>*/