using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiJobCandidateModelValidator: AbstractApiJobCandidateModelValidator, IApiJobCandidateModelValidator
	{
		public ApiJobCandidateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiJobCandidateModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiJobCandidateModel model)
		{
			this.BusinessEntityIDRules();
			this.ModifiedDateRules();
			this.ResumeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>30689cea5f94bdc2d4fd071e536f9b5b</Hash>
</Codenesium>*/