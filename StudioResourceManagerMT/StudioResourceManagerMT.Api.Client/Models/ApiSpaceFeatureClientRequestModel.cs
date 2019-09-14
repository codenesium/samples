using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiSpaceFeatureClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpaceFeatureClientRequestModel()
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
    <Hash>42c8984e65bff65d87388f782560cdee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/