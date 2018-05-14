using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesOrderHeaderSalesReasonModelValidator: AbstractApiSalesOrderHeaderSalesReasonModelValidator, IApiSalesOrderHeaderSalesReasonModelValidator
	{
		public ApiSalesOrderHeaderSalesReasonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderHeaderSalesReasonModel model)
		{
			this.ModifiedDateRules();
			this.SalesReasonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderHeaderSalesReasonModel model)
		{
			this.ModifiedDateRules();
			this.SalesReasonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>86403c4a8df47f6255c106a440564128</Hash>
</Codenesium>*/