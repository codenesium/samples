using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatuRequestModelValidator : AbstractApiTicketStatuRequestModelValidator, IApiTicketStatuRequestModelValidator
	{
		public ApiTicketStatuRequestModelValidator(ITicketStatuRepository ticketStatuRepository)
			: base(ticketStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatuRequestModel model)
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
    <Hash>4fe69348fbd396a8d678c30b1d24d63b</Hash>
</Codenesium>*/