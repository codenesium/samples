using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiVenueRequestModelValidator: AbstractApiVenueRequestModelValidator, IApiVenueRequestModelValidator
        {
                public ApiVenueRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiVenueRequestModel model)
                {
                        this.Address1Rules();
                        this.Address2Rules();
                        this.AdminIdRules();
                        this.EmailRules();
                        this.FacebookRules();
                        this.NameRules();
                        this.PhoneRules();
                        this.ProvinceIdRules();
                        this.WebsiteRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueRequestModel model)
                {
                        this.Address1Rules();
                        this.Address2Rules();
                        this.AdminIdRules();
                        this.EmailRules();
                        this.FacebookRules();
                        this.NameRules();
                        this.PhoneRules();
                        this.ProvinceIdRules();
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
    <Hash>266da57386ed98b83a18533f308eac57</Hash>
</Codenesium>*/