using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketServerRequestModelValidator : AbstractApiTicketServerRequestModelValidator, IApiTicketServerRequestModelValidator
	{
		public ApiTicketServerRequestModelValidator(ITicketRepository ticketRepository)
			: base(ticketRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketServerRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketServerRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b679834e93213f398eb1189c77cc9ddd</Hash>
</Codenesium>*/