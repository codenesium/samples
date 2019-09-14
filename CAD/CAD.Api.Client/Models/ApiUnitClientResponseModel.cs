using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiUnitClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string callSign)
		{
			this.Id = id;
			this.CallSign = callSign;
		}

		[JsonProperty]
		public string CallSign { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>12eecf7d6ee452617f69b188d09bc49c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/