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
    <Hash>c6918b3dff8c1b29ff413f16d23f8066</Hash>
</Codenesium>*/