using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesOrderHeaderSalesReasonModelValidator: AbstractSalesOrderHeaderSalesReasonModelValidator, ISalesOrderHeaderSalesReasonModelValidator
	{
		public SalesOrderHeaderSalesReasonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesOrderHeaderSalesReasonModel model)
		{
			this.ModifiedDateRules();
			this.SalesReasonIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderSalesReasonModel model)
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
    <Hash>0d3e36d5674388ac32ca51f5dababcef</Hash>
</Codenesium>*/