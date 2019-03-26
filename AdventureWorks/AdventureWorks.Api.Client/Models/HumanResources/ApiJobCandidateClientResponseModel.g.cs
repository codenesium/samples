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

			this.BusinessEntityIDEntity = nameof(ApiResponse.Employees);
		}

		[JsonProperty]
		public ApiEmployeeClientResponseModel BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(ApiEmployeeClientResponseModel value)
		{
			this.BusinessEntityIDNavigation = value;
		}

		[JsonProperty]
		public int? BusinessEntityID { get; private set; }

		[JsonProperty]
		public string BusinessEntityIDEntity { get; set; }

		[JsonProperty]
		public int JobCandidateID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1d81ccdd40f79417bba0d4ce4bc7269a</Hash>
</Codenesium>*/