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
        public abstract class AbstractApiShiftRequestModelValidator: AbstractValidator<ApiShiftRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiShiftRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiShiftRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IShiftRepository ShiftRepository { get; set; }
                public virtual void EndTimeRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStartTimeEndTime).When(x => x ?.EndTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.EndTime));
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void StartTimeRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStartTimeEndTime).When(x => x ?.StartTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.StartTime));
                }

                private async Task<bool> BeUniqueGetName(ApiShiftRequestModel model,  CancellationToken cancellationToken)
                {
                        Shift record = await this.ShiftRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.ShiftID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetStartTimeEndTime(ApiShiftRequestModel model,  CancellationToken cancellationToken)
                {
                        Shift record = await this.ShiftRepository.GetStartTimeEndTime(model.StartTime, model.EndTime);

                        if (record == null || (this.existingRecordId != default (int) && record.ShiftID == this.existingRecordId))
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
    <Hash>250e5f22f93d483673d0abe21280ccbe</Hash>
</Codenesium>*/