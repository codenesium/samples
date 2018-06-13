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
        public abstract class AbstractApiLocationRequestModelValidator: AbstractValidator<ApiLocationRequestModel>
        {
                private short existingRecordId;

                public ValidationResult Validate(ApiLocationRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiLocationRequestModel model, short id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ILocationRepository LocationRepository { get; set; }
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLocationRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiLocationRequestModel model,  CancellationToken cancellationToken)
                {
                        Location record = await this.LocationRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (short) && record.LocationID == this.existingRecordId))
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
    <Hash>1e8b6939c792ec77f7172b580b6626cf</Hash>
</Codenesium>*/