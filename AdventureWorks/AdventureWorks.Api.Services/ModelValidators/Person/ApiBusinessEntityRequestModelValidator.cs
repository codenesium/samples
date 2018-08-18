using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBusinessEntityRequestModelValidator : AbstractApiBusinessEntityRequestModelValidator, IApiBusinessEntityRequestModelValidator
	{
		public ApiBusinessEntityRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
			: base(businessEntityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model)
		{
			this.ModifiedDateRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model)
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
    <Hash>683ac45d8dbf05bda53f440509d58c6e</Hash>
</Codenesium>*/