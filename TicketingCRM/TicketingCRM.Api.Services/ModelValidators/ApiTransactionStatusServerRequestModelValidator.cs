using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionStatusServerRequestModelValidator : AbstractApiTransactionStatusServerRequestModelValidator, IApiTransactionStatusServerRequestModelValidator
	{
		public ApiTransactionStatusServerRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
			: base(transactionStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusServerRequestModel model)
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
    <Hash>fbe748b3825b066daac2c309d8131fd9</Hash>
</Codenesium>*/