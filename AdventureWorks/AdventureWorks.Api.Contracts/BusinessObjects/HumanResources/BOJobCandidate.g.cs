using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>a51242f406fa3c36353fea1f2cebc6f4</Hash>
</Codenesium>*/