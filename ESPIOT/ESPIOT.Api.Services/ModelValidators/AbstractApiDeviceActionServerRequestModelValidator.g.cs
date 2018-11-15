using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceActionServerRequestModelValidator : AbstractValidator<ApiDeviceActionServerRequestModel>
	{
		private int existingRecordId;

		private IDeviceActionRepository deviceActionRepository;

		public AbstractApiDeviceActionServerRequestModelValidator(IDeviceActionRepository deviceActionRepository)
		{
			this.deviceActionRepository = deviceActionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDeviceByDeviceId).When(x => !x?.DeviceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void @ValueRules()
		{
			this.RuleFor(x => x.@Value).NotNull();
			this.RuleFor(x => x.@Value).Length(0, 4000);
		}

		private async Task<bool> BeValidDeviceByDeviceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.deviceActionRepository.DeviceByDeviceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6f73a386aa288648136550bbe9feb077</Hash>
</Codenesium>*/