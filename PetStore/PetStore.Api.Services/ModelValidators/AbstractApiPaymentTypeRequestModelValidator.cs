using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractApiPaymentTypeRequestModelValidator : AbstractValidator<ApiPaymentTypeRequestModel>
        {
                private int existingRecordId;

                private IPaymentTypeRepository paymentTypeRepository;

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
    <Hash>ff4532d13126373c24a43e86accc83a4</Hash>
</Codenesium>*/