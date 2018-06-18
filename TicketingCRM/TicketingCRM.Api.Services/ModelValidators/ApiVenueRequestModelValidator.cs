using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiVenueRequestModelValidator: AbstractApiVenueRequestModelValidator, IApiVenueRequestModelValidator
        {
                public ApiVenueRequestModelValidator(IVenueRepository venueRepository)
                        : base(venueRepository)
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
    <Hash>bdec62b39da0efdd7e1a7cb9163a6725</Hash>
</Codenesium>*/