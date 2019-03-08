using Codenesium.DataConversionExtensions;
using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public abstract class AbstractApiDeviceActionServerRequestModelValidator : AbstractValidator<ApiDeviceActionServerRequestModel>
	{
		private int existingRecordId;

		protected IDeviceActionRepository DeviceActionRepository { get; private set; }

		public AbstractApiDeviceActionServerRequestModelValidator(IDeviceActionRepository deviceActionRepository)
		{
			this.DeviceActionRepository = deviceActionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActionRules()
		{
			this.RuleFor(x => x.Action).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDeviceByDeviceId).When(x => !x?.DeviceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidDeviceByDeviceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DeviceActionRepository.DeviceByDeviceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>05ab4b75e77741737d55229730b8aaba</Hash>
</Codenesium>*/