using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTicketStatusRequestModelValidator : AbstractApiTicketStatusRequestModelValidator, IApiTicketStatusRequestModelValidator
	{
		public ApiTicketStatusRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
			: base(ticketStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model)
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
    <Hash>54709c65cad02eb4fb728252e398746c</Hash>
</Codenesium>*/