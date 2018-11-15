using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiEventServerRequestModelValidator : AbstractApiEventServerRequestModelValidator, IApiEventServerRequestModelValidator
	{
		public ApiEventServerRequestModelValidator(IEventRepository eventRepository)
			: base(eventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityIdRules();
			this.DateRules();
			this.DescriptionRules();
			this.EndDateRules();
			this.FacebookRules();
			this.NameRules();
			this.StartDateRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityIdRules();
			this.DateRules();
			this.DescriptionRules();
			this.EndDateRules();
			this.FacebookRules();
			this.NameRules();
			this.StartDateRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4d95052bde9115409ff68e2b2e224fac</Hash>
</Codenesium>*/