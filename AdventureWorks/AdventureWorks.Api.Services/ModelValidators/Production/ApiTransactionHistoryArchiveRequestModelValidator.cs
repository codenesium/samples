using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiTransactionHistoryArchiveRequestModelValidator : AbstractApiTransactionHistoryArchiveRequestModelValidator, IApiTransactionHistoryArchiveRequestModelValidator
	{
		public ApiTransactionHistoryArchiveRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
			: base(transactionHistoryArchiveRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model)
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
    <Hash>a8463feae64c1e4e6c5f109d290ed0c4</Hash>
</Codenesium>*/