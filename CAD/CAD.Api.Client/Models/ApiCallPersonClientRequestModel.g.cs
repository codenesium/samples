using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiCallPersonClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCallPersonClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string note,
			int personId,
			int personTypeId)
		{
			this.Note = note;
			this.PersonId = personId;
			this.PersonTypeId = personTypeId;
		}

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public int PersonTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fba6ed954e881ae1abfc7f2ba1af2555</Hash>
</Codenesium>*/