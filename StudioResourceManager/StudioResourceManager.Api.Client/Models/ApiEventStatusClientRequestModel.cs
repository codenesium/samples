using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiEventStatusClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEventStatusClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name)
		{
			this.Name = name;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>280daf7bc7da8c4e47ff4c3086305466</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/