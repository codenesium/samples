using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiJobCandidateServerRequestModelValidator : AbstractApiJobCandidateServerRequestModelValidator, IApiJobCandidateServerRequestModelValidator
	{
		public ApiJobCandidateServerRequestModelValidator(IJobCandidateRepository jobCandidateRepository)
			: base(jobCandidateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateServerRequestModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateServerRequestModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8aab93a0fb5c6f13b36aaf8470b1265d</Hash>
</Codenesium>*/