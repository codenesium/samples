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
			this.SalesReasonIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderHeaderSalesReasonModel model)
		{
			this.SalesReasonIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>cbf1833cd6720e5f793fac0940cef7a5</Hash>
</Codenesium>*/