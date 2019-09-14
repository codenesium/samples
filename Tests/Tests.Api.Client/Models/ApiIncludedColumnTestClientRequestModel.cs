using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiIncludedColumnTestClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiIncludedColumnTestClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			string name2)
		{
			this.Name = name;
			this.Name2 = name2;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string Name2 { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>990b41f4ea3f80d1ec52bebcf048e0ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/