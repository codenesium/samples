using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public abstract class AbstractApiDeviceRequestModelValidator: AbstractValidator<ApiDeviceRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiDeviceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeviceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IDeviceRepository DeviceRepository { get; set; }
                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 90);
                }

                public virtual void PublicIdRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByPublicId).When(x => x ?.PublicId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceRequestModel.PublicId));
                }

                private async Task<bool> BeUniqueByPublicId(ApiDeviceRequestModel model,  CancellationToken cancellationToken)
                {
                        Device record = await this.DeviceRepository.ByPublicId(model.PublicId);

                        if (record == null || (this.existingRecordId != default (int) && record.Id == this.existingRecordId))
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
    <Hash>066652a55c8ea681705cc52440159bf7</Hash>
</Codenesium>*/