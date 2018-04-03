using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOJobCandidate
	{
		public POCOJobCandidate()
		{}

		public POCOJobCandidate(int jobCandidateID,
		                        Nullable<int> businessEntityID,
		                        string resume,
		                        DateTime modifiedDate)
		{
			this.JobCandidateID = jobCandidateID.ToInt();
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int JobCandidateID {get; set;}
		public Nullable<int> BusinessEntityID {get; set;}
		public string Resume {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeJobCandidateIDValue {get; set;} = true;

		public bool ShouldSerializeJobCandidateID()
		{
			return ShouldSerializeJobCandidateIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBusinessEntityIDValue {get; set;} = true;

		public bool ShouldSerializeBusinessEntityID()
		{
			return ShouldSerializeBusinessEntityIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResumeValue {get; set;} = true;

		public bool ShouldSerializeResume()
		{
			return ShouldSerializeResumeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>9cba97b66ce151b7fe1c3867d17ddc3c</Hash>
</Codenesium>*/