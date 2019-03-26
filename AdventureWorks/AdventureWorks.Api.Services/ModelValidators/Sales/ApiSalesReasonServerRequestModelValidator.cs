using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesReasonServerRequestModelValidator : AbstractApiSalesReasonServerRequestModelValidator, IApiSalesReasonServerRequestModelValidator
	{
		public ApiSalesReasonServerRequestModelValidator(ISalesReasonRepository salesReasonRepository)
			: base(salesReasonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>707a3ce27f37d603b69bce5c63b92960</Hash>
</Codenesium>*/