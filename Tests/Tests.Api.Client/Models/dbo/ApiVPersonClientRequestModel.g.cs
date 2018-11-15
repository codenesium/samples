using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiVPersonClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVPersonClientRequestModel()
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
    <Hash>6e4f696d0b7572426e26632e943b674a</Hash>
</Codenesium>*/