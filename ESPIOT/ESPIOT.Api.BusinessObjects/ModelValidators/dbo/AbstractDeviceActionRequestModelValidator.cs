using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

{
	public abstract class AbstractApiDeviceActionRequestModelValidator: AbstractValidator<ApiDeviceActionRequestModel>
	{
		public new ValidationResult Validate(ApiDeviceActionRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDeviceRepository DeviceRepository { get; set; }
		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).NotNull();
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDevice).When(x => x ?.DeviceId != null).WithMessage("Invalid reference");
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

		private async Task<bool> BeValidDevice(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DeviceRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0e70c221ab2111183175ac3d997017e9</Hash>
</Codenesium>*/