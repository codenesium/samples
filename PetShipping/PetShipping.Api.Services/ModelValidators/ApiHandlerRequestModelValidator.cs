using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiHandlerRequestModelValidator : AbstractApiHandlerRequestModelValidator, IApiHandlerRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>16c7a5f562955cea89ee1651554d5638</Hash>
</Codenesium>*/