using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiLibraryVariableSetRequestModel : AbstractApiRequestModel
	{
		public ApiLibraryVariableSetRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string contentType,
			string jSON,
			string name,
			string variableSetId)
		{
			this.ContentType = contentType;
			this.JSON = jSON;
			this.Name = name;
			this.VariableSetId = variableSetId;
		}

		[JsonProperty]
		public string ContentType { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>54613f4a10b4294924029df1ac277508</Hash>
</Codenesium>*/