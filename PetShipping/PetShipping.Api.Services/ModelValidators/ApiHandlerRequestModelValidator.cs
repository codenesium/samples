using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiHandlerRequestModelValidator: AbstractApiHandlerRequestModelValidator, IApiHandlerRequestModelValidator
        {
                public ApiHandlerRequestModelValidator(IHandlerRepository handlerRepository)
                        : base(handlerRepository)
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
    <Hash>7cb39471449704f2f26ed34fbf5c1421</Hash>
</Codenesium>*/