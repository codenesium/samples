using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>57b9b299c8d40f560b25eeaa115b9f44</Hash>
</Codenesium>*/