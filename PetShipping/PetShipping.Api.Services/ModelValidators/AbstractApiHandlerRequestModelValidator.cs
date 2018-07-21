using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiHandlerRequestModelValidator : AbstractValidator<ApiHandlerRequestModel>
        {
                private int existingRecordId;

                private IHandlerRepository handlerRepository;

                public AbstractApiHandlerRequestModelValidator(IHandlerRepository handlerRepository)
                {
                        this.handlerRepository = handlerRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiHandlerRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CountryIdRules()
                {
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).Length(0, 128);
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).Length(0, 10);
                }
        }
}

/*<Codenesium>
    <Hash>8c592a62d2d700022e353ee3fdffa76b</Hash>
</Codenesium>*/