using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiJobCandidateServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiJobCandidateServerRequestModel()
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
		public int? BusinessEntityID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Resume { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>411fdb6d7c14cc503dff35b6f079461a</Hash>
</Codenesium>*/