using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Client
{
	public partial class ApiPostTypeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPostTypeClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string rwType)
		{
			this.RwType = rwType;
		}

		[JsonProperty]
		public string RwType { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>b749f0415804c14214ecd0ff9508a6a7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/