using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiSpaceClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpaceClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string name)
		{
			this.Description = description;
			this.Name = name;
		}

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>10479c124a2c6e42641f371920d7cee5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/