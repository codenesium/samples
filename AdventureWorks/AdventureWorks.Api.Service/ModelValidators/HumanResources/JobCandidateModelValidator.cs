using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class JobCandidateModelValidator: AbstractJobCandidateModelValidator, IJobCandidateModelValidator
	{
		public JobCandidateModelValidator()
		{   }

		public void CreateMode()
		{
			this.BusinessEntityIDRules();
			this.ResumeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.BusinessEntityIDRules();
			this.ResumeRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>ecd1b7eab087edf46f7e9dfee9e0e2ef</Hash>
</Codenesium>*/