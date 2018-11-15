using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiJobCandidateClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int jobCandidateID,
			int? businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.JobCandidateID = jobCandidateID;
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		[JsonProperty]
		public int? BusinessEntityID { get; private set; }

		[JsonProperty]
		public int JobCandidateID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>85c8f07e2ab0a4cab37f59f30552b0d4</Hash>
</Codenesium>*/