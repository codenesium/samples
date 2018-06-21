using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiLocationRequestModelValidator : AbstractValidator<ApiLocationRequestModel>
        {
                private short existingRecordId;

                private ILocationRepository locationRepository;

                public AbstractApiLocationRequestModelValidator(ILocationRepository locationRepository)
                {
                        this.locationRepository = locationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiLocationRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AvailabilityRules()
                {
                }

                public virtual void CostRateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueByName(ApiLocationRequestModel model,  CancellationToken cancellationToken)
                {
                        Location record = await this.locationRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(short) && record.LocationID == this.existingRecordId))
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
    <Hash>d13ca208ddd9096cb3fde7920cd6c018</Hash>
</Codenesium>*/