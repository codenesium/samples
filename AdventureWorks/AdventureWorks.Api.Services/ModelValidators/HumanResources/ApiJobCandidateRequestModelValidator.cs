using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiJobCandidateRequestModelValidator: AbstractApiJobCandidateRequestModelValidator, IApiJobCandidateRequestModelValidator
	{
		public ApiJobCandidateRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateRequestModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateRequestModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0080324092e31cfd282b3a56f1dea50d</Hash>
</Codenesium>*/