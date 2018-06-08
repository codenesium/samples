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
                        this.RuleFor(x => x.Availability).NotNull();
                }

                public virtual void CostRateRules()
                {
                        this.RuleFor(x => x.CostRate).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
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

                        if (record == null || record.LocationID == this.existingRecordId)
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
    <Hash>9c3fbff3638fde1c39a6adf2b6a82405</Hash>
</Codenesium>*/