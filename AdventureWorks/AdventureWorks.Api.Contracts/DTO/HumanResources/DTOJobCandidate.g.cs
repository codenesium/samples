using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOJobCandidate: AbstractDTO
	{
		public DTOJobCandidate() : base()
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

		public Nullable<int> BusinessEntityID { get; set; }
		public int JobCandidateID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Resume { get; set; }
	}
}

/*<Codenesium>
    <Hash>b3963d6922169c8bcfe4c1e551c2a79b</Hash>
</Codenesium>*/