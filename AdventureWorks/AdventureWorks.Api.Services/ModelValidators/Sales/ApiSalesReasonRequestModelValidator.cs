using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesReasonRequestModelValidator: AbstractApiSalesReasonRequestModelValidator, IApiSalesReasonRequestModelValidator
	{
		public ApiSalesReasonRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>98394604bb41fff33e0c9ed49a17265e</Hash>
</Codenesium>*/