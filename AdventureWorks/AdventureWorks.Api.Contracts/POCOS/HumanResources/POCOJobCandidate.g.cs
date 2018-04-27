using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOJobCandidate
	{
		public POCOJobCandidate()
		{}

		public POCOJobCandidate(
			Nullable<int> businessEntityID,
			int jobCandidateID,
			DateTime modifiedDate,
			string resume)
		{
			this.JobCandidateID = jobCandidateID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Resume = resume;

			this.BusinessEntityID = new ReferenceEntity<Nullable<int>>(businessEntityID,
			                                                           nameof(ApiResponse.Employees));
		}

		public ReferenceEntity<Nullable<int>> BusinessEntityID { get; set; }
		public int JobCandidateID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Resume { get; set; }

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
    <Hash>bf77e11c99542155131cad34d3a54a92</Hash>
</Codenesium>*/