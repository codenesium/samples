using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiTransactionHistoryArchiveModelValidator: AbstractApiTransactionHistoryArchiveModelValidator, IApiTransactionHistoryArchiveModelValidator
	{
		public ApiTransactionHistoryArchiveModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveModel model)
		{
			this.ActualCostRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveModel model)
		{
			this.ActualCostRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5ec1715dd56df9ae4d760d286a544031</Hash>
</Codenesium>*/