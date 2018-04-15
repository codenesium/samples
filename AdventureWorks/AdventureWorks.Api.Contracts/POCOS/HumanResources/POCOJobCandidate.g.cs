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
			int jobCandidateID,
			Nullable<int> businessEntityID,
			string resume,
			DateTime modifiedDate)
		{
			this.JobCandidateID = jobCandidateID.ToInt();
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.BusinessEntityID = new ReferenceEntity<Nullable<int>>(businessEntityID,
			                                                           nameof(ApiResponse.Employees));
		}

		public int JobCandidateID { get; set; }
		public ReferenceEntity<Nullable<int>> BusinessEntityID { get; set; }
		public string Resume { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeJobCandidateIDValue { get; set; } = true;

		public bool ShouldSerializeJobCandidateID()
		{
			return this.ShouldSerializeJobCandidateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return this.ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResumeValue { get; set; } = true;

		public bool ShouldSerializeResume()
		{
			return this.ShouldSerializeResumeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeJobCandidateIDValue = false;
			this.ShouldSerializeBusinessEntityIDValue = false;
			this.ShouldSerializeResumeValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5415230081104d6e77c31f72caef02eb</Hash>
</Codenesium>*/