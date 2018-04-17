using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class JobCandidateModelValidator: AbstractJobCandidateModelValidator, IJobCandidateModelValidator
	{
		public JobCandidateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(JobCandidateModel model)
		{
			this.BusinessEntityIDRules();
			this.ResumeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, JobCandidateModel model)
		{
			this.BusinessEntityIDRules();
			this.ResumeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1ecaefbea6175bd8a3ac038f75b1acc6</Hash>
</Codenesium>*/