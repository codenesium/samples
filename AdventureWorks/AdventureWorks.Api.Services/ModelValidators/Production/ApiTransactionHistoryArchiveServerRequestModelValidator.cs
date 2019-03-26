using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiTransactionHistoryArchiveServerRequestModelValidator : AbstractApiTransactionHistoryArchiveServerRequestModelValidator, IApiTransactionHistoryArchiveServerRequestModelValidator
	{
		public ApiTransactionHistoryArchiveServerRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
			: base(transactionHistoryArchiveRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveServerRequestModel model)
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
    <Hash>5b992d649278fdd7b8a2d3961087e112</Hash>
</Codenesium>*/