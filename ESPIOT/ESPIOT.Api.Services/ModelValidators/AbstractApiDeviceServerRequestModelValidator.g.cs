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

		protected IDeviceRepository DeviceRepository { get; private set; }

		public AbstractApiDeviceServerRequestModelValidator(IDeviceRepository deviceRepository)
		{
			this.DeviceRepository = deviceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByPublicId).When(x => (!x?.PublicId.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceServerRequestModel.PublicId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByPublicId(ApiDeviceServerRequestModel model,  CancellationToken cancellationToken)
		{
			Device record = await this.DeviceRepository.ByPublicId(model.PublicId);

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
    <Hash>3db5a89a80eb9eb0c8a624587fce9cf7</Hash>
</Codenesium>*/