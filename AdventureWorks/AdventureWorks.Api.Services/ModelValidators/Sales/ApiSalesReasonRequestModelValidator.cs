using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesReasonRequestModelValidator : AbstractApiSalesReasonRequestModelValidator, IApiSalesReasonRequestModelValidator
	{
		public ApiSalesReasonRequestModelValidator(ISalesReasonRepository salesReasonRepository)
			: base(salesReasonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ReasonTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonRequestModel model)
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
    <Hash>4cff7f4efcbd5a647df5eeac4fbd5635</Hash>
</Codenesium>*/