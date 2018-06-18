using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiEventRequestModelValidator: AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>7839e7a1151424ed7e8cad7bc377fcae</Hash>
</Codenesium>*/