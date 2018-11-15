using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionStatuServerRequestModelValidator : AbstractApiTransactionStatuServerRequestModelValidator, IApiTransactionStatuServerRequestModelValidator
	{
		public ApiTransactionStatuServerRequestModelValidator(ITransactionStatuRepository transactionStatuRepository)
			: base(transactionStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatuServerRequestModel model)
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
    <Hash>0162e0ac999a36d021a5e6c566d56e6f</Hash>
</Codenesium>*/