using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionRequestModelValidator : AbstractApiTransactionRequestModelValidator, IApiTransactionRequestModelValidator
	{
		public ApiTransactionRequestModelValidator(ITransactionRepository transactionRepository)
			: base(transactionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionRequestModel model)
		{
			this.AmountRules();
			this.GatewayConfirmationNumberRules();
			this.TransactionStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionRequestModel model)
		{
			this.AmountRules();
			this.GatewayConfirmationNumberRules();
			this.TransactionStatusIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>1c1b79874d9f7d69eda4459de0c218b9</Hash>
</Codenesium>*/