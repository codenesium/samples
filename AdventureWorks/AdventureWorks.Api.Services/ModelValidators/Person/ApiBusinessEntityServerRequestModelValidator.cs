using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBusinessEntityServerRequestModelValidator : AbstractApiBusinessEntityServerRequestModelValidator, IApiBusinessEntityServerRequestModelValidator
	{
		public ApiBusinessEntityServerRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
			: base(businessEntityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f39d2b3d0f464a60a767f1dbe07c9f18</Hash>
</Codenesium>*/