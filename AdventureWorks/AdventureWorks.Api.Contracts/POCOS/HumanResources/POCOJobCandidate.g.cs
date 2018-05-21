using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOJobCandidate: AbstractPOCO
	{
		public POCOJobCandidate() : base()
		{}

		public POCOJobCandidate(
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

		public Nullable<int> BusinessEntityID { get; set; }
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
    <Hash>0d16ffa018ee1b7c2aa311c419efbb4f</Hash>
</Codenesium>*/