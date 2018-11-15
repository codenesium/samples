using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiTransactionHistoryServerRequestModelValidator : AbstractApiTransactionHistoryServerRequestModelValidator, IApiTransactionHistoryServerRequestModelValidator
	{
		public ApiTransactionHistoryServerRequestModelValidator(ITransactionHistoryRepository transactionHistoryRepository)
			: base(transactionHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryServerRequestModel model)
		{
			this.ActualCostRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.QuantityRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3c50ce59326dedb750c0a5d9ade72458</Hash>
</Codenesium>*/