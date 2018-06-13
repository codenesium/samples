using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiEventRequestModelValidator: AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
        {
                public ApiEventRequestModelValidator()
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
    <Hash>40ba77471c931f2cd459ca8e6eb5c389</Hash>
</Codenesium>*/