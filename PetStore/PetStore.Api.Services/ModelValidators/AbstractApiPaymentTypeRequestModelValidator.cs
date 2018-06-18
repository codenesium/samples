using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractApiPaymentTypeRequestModelValidator: AbstractValidator<ApiPaymentTypeRequestModel>
        {
                private int existingRecordId;

                IPaymentTypeRepository paymentTypeRepository;

                public AbstractApiPaymentTypeRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
                {
                        this.paymentTypeRepository = paymentTypeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPaymentTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>c68b34500c749c75ff9e47d9e8dc4e7c</Hash>
</Codenesium>*/