using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiCountryRequestModelValidator: AbstractValidator<ApiCountryRequestModel>
        {
                private int existingRecordId;

                ICountryRepository countryRepository;

                public AbstractApiCountryRequestModelValidator(ICountryRepository countryRepository)
                {
                        this.countryRepository = countryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCountryRequestModel model, int id)
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
    <Hash>8eb0fd9609799a2163538aeabe416c38</Hash>
</Codenesium>*/