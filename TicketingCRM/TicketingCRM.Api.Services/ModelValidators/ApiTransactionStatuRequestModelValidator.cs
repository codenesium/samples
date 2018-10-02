using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionStatuRequestModelValidator : AbstractApiTransactionStatuRequestModelValidator, IApiTransactionStatuRequestModelValidator
	{
		public ApiTransactionStatuRequestModelValidator(ITransactionStatuRepository transactionStatuRepository)
			: base(transactionStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatuRequestModel model)
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
    <Hash>03c661c6a5b1dbb1a16c6ec8befd2e03</Hash>
</Codenesium>*/