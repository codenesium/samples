using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatusServerRequestModelValidator : AbstractApiTicketStatusServerRequestModelValidator, IApiTicketStatusServerRequestModelValidator
	{
		public ApiTicketStatusServerRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
			: base(ticketStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusServerRequestModel model)
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
    <Hash>bb41d41d3d5713f969401bccc24407f7</Hash>
</Codenesium>*/