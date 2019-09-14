using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiUnitClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUnitClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string callSign)
		{
			this.CallSign = callSign;
		}

		[JsonProperty]
		public string CallSign { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>e8082413af7357c5b3c057a605e29331</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/