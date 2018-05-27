using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiScrapReasonRequestModelValidator: AbstractApiScrapReasonRequestModelValidator, IApiScrapReasonRequestModelValidator
	{
		public ApiScrapReasonRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>123f5acd21a58688892b950c0dbf3324</Hash>
</Codenesium>*/