using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatuServerRequestModelValidator : AbstractApiTicketStatuServerRequestModelValidator, IApiTicketStatuServerRequestModelValidator
	{
		public ApiTicketStatuServerRequestModelValidator(ITicketStatuRepository ticketStatuRepository)
			: base(ticketStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatuServerRequestModel model)
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
    <Hash>947d4235336b39ca712266c37e6e87fe</Hash>
</Codenesium>*/