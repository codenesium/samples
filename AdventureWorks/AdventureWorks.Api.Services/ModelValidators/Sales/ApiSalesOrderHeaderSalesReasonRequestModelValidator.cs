using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesOrderHeaderSalesReasonRequestModelValidator: AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator, IApiSalesOrderHeaderSalesReasonRequestModelValidator
	{
		public ApiSalesOrderHeaderSalesReasonRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.SalesReasonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			this.ModifiedDateRules();
			this.SalesReasonIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>46840cf93e1d55f99a4e11e27a7189bb</Hash>
</Codenesium>*/