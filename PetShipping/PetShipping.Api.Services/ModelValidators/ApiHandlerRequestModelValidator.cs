using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiHandlerRequestModelValidator: AbstractApiHandlerRequestModelValidator, IApiHandlerRequestModelValidator
        {
                public ApiHandlerRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model)
                {
                        this.CountryIdRules();
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model)
                {
                        this.CountryIdRules();
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d32cd0138ee13e0de113c09948a5832b</Hash>
</Codenesium>*/