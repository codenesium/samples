using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiPersonClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPersonClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string personName)
		{
			this.PersonName = personName;
		}

		[JsonProperty]
		public string PersonName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>0681311fb6c3c07c947e38244230a401</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/