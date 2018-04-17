using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class TransactionHistoryArchiveModelValidator: AbstractTransactionHistoryArchiveModelValidator, ITransactionHistoryArchiveModelValidator
	{
		public TransactionHistoryArchiveModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(TransactionHistoryArchiveModel model)
		{
			this.ProductIDRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			this.QuantityRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, TransactionHistoryArchiveModel model)
		{
			this.ProductIDRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			this.QuantityRules();
			this.ActualCostRules();
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
    <Hash>49a7c54a1eaca5355c99292e3ba72699</Hash>
</Codenesium>*/