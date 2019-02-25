using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiJobCandidateServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public int? BusinessEntityID { get; private set; }

		[JsonProperty]
		public string BusinessEntityIDEntity { get; private set; } = RouteConstants.Employees;

		[JsonProperty]
		public ApiEmployeeServerResponseModel BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(ApiEmployeeServerResponseModel value)
		{
			this.BusinessEntityIDNavigation = value;
		}

		[JsonProperty]
		public int JobCandidateID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>857339c6abac4dde3352d0ffbe433756</Hash>
</Codenesium>*/