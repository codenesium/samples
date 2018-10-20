using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiJobCandidateRequestModel : AbstractApiRequestModel
	{
		public ApiJobCandidateRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public string Resume { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>dfdedef5355826fc225ee4263bcd47bc</Hash>
</Codenesium>*/