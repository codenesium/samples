using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiIllustrationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiIllustrationServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;
	}
}

/*<Codenesium>
    <Hash>61f5b71e6f072be31238b4711280864d</Hash>
</Codenesium>*/