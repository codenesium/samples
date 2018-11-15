using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionServerRequestModelValidator : AbstractApiTransactionServerRequestModelValidator, IApiTransactionServerRequestModelValidator
	{
		public ApiTransactionServerRequestModelValidator(ITransactionRepository transactionRepository)
			: base(transactionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionServerRequestModel model)
		{
			this.AmountRules();
			this.GatewayConfirmationNumberRules();
			this.TransactionStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionServerRequestModel model)
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
    <Hash>51d913b5a8191a5ca6c5e143dfb0a791</Hash>
</Codenesium>*/