using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiCountryRegionRequestModelValidator: AbstractValidator<ApiCountryRegionRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiCountryRegionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCountryRegionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICountryRegionRepository CountryRegionRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiCountryRegionRequestModel model,  CancellationToken cancellationToken)
                {
                        CountryRegion record = await this.CountryRegionRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.CountryRegionCode == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d54be00fa15fdcbe33492db66b4e519d</Hash>
</Codenesium>*/