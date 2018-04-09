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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>fda286063791f80e04a83647efce6fb2</Hash>
</Codenesium>*/