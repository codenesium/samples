using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationRequestModel : AbstractApiRequestModel
	{
		public ApiIllustrationRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);
	}
}

/*<Codenesium>
    <Hash>9db0d5bb93d065a82790a0994e02dfc1</Hash>
</Codenesium>*/