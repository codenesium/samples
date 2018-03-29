using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class JobCandidateModelValidator: AbstractJobCandidateModelValidator,IJobCandidateModelValidator
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

		public void PatchMode()
		{
			this.BusinessEntityIDRules();
			this.ResumeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>653483d171e7ebb45ab8267583fd2a3c</Hash>
</Codenesium>*/