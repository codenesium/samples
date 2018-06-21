using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public class ApiPaymentTypeRequestModelValidator : AbstractApiPaymentTypeRequestModelValidator, IApiPaymentTypeRequestModelValidator
        {
                public ApiPaymentTypeRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
                        : base(paymentTypeRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model)
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
    <Hash>49c452e0641729de5ff730ce245c8400</Hash>
</Codenesium>*/