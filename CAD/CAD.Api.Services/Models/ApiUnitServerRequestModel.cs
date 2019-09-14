using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiUnitServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiUnitServerRequestModel()
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
    <Hash>b570bee3a746484ea95cac05511e7613</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/