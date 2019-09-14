using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiCountryClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCountryClientRequestModel()
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
    <Hash>2cea8b0898247825275ddfe657d8de24</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/