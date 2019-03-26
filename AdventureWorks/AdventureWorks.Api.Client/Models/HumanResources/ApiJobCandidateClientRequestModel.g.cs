using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiJobCandidateClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiJobCandidateClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		[JsonProperty]
		public int? BusinessEntityID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Resume { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>241a43b0073ff7c4e6588b385f2744a2</Hash>
</Codenesium>*/