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
        public abstract class AbstractApiCountryRequirementRequestModelValidator: AbstractValidator<ApiCountryRequirementRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiCountryRequirementRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCountryRequirementRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICountryRepository CountryRepository { get; set; }

                public virtual void CountryIdRules()
                {
                        this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
                }

                public virtual void DetailsRules()
                {
                        this.RuleFor(x => x.Details).NotNull();
                        this.RuleFor(x => x.Details).Length(0, 2147483647);
                }

                private async Task<bool> BeValidCountry(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.CountryRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>e04863c4578afa89c1f4428b4939f85c</Hash>
</Codenesium>*/