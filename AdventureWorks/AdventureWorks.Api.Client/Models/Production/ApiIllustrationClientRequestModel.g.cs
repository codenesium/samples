using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiIllustrationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiIllustrationClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string diagram,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate;
		}

		[JsonProperty]
		public string Diagram { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>3f1dc0f61b65465a0b18183841c6dc49</Hash>
</Codenesium>*/