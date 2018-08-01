using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionStatusRequestModelValidator : AbstractApiTransactionStatusRequestModelValidator, IApiTransactionStatusRequestModelValidator
	{
		public ApiTransactionStatusRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
			: base(transactionStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d4198017e589eb9b52a18d1a2bf57390</Hash>
</Codenesium>*/