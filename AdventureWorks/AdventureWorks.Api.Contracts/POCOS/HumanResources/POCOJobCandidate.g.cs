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
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();

			BusinessEntityID = new ReferenceEntity<Nullable<int>>(businessEntityID,
			                                                      "Employee");
		}

		public int JobCandidateID {get; set;}
		public ReferenceEntity<Nullable<int>>BusinessEntityID {get; set;}
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
    <Hash>564c5c304c55735b9be1b6dce3fdb7f9</Hash>
</Codenesium>*/