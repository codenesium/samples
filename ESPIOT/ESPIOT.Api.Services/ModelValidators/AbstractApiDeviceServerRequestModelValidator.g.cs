using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceServerRequestModelValidator : AbstractValidator<ApiDeviceServerRequestModel>
	{
		private int existingRecordId;

		private IDeviceRepository deviceRepository;

		public AbstractApiDeviceServerRequestModelValidator(IDeviceRepository deviceRepository)
		{
			this.deviceRepository = deviceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByPublicId).When(x => !x?.PublicId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceServerRequestModel.PublicId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		private async Task<bool> BeUniqueByPublicId(ApiDeviceServerRequestModel model,  CancellationToken cancellationToken)
		{
			Device record = await this.deviceRepository.ByPublicId(model.PublicId);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
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
    <Hash>ea1d28332417b130a10cddb18cbd5465</Hash>
</Codenesium>*/