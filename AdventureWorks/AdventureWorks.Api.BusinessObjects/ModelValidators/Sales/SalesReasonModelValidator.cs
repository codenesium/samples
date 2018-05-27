using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a5e8740f1f3a1ba9208ffeb703b4efc9</Hash>
</Codenesium>*/