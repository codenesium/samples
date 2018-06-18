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

                IDeviceRepository deviceRepository;

                public AbstractApiDeviceRequestModelValidator(IDeviceRepository deviceRepository)
                {
                        this.deviceRepository = deviceRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeviceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        Device record = await this.deviceRepository.ByPublicId(model.PublicId);

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
    <Hash>5723a232004e1e9bdcc8071856fb2ea5</Hash>
</Codenesium>*/