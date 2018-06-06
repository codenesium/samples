using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOJobCandidate: AbstractBusinessObject
	{
		public BOJobCandidate() : base()
		{}

		public void SetProperties(int jobCandidateID,
		                          Nullable<int> businessEntityID,
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
	}
}

/*<Codenesium>
    <Hash>cb65c3e23f49e82d7a8d74b0a76d548b</Hash>
</Codenesium>*/