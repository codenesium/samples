using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiJobCandidateResponseModel: AbstractApiResponseModel
	{
		public ApiJobCandidateResponseModel() : base()
		{}

		public void SetProperties(
			Nullable<int> businessEntityID,
			int jobCandidateID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.JobCandidateID = jobCandidateID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Resume = resume;
		}

		public Nullable<int> BusinessEntityID { get; private set; }
		public int JobCandidateID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Resume { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeJobCandidateIDValue { get; set; } = true;

		public bool ShouldSerializeJobCandidateID()
		{
			return this.ShouldSerializeJobCandidateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResumeValue { get; set; } = true;

		public bool ShouldSerializeResume()
		{
			return this.ShouldSerializeResumeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeJobCandidateIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeResumeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f9e15dd3348e9d28f4e524f586895779</Hash>
</Codenesium>*/