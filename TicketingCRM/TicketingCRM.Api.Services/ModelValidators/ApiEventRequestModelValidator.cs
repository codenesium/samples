using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiEventRequestModelValidator : AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
	{
		public ApiEventRequestModelValidator(IEventRepository eventRepository)
			: base(eventRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRequestModel model)
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
    <Hash>9f9f8e8f8b42f06a337f5cf93727f1c5</Hash>
</Codenesium>*/