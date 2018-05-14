using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

{
	public abstract class AbstractApiDeviceActionModelValidator: AbstractValidator<ApiDeviceActionModel>
	{
		public new ValidationResult Validate(ApiDeviceActionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDeviceRepository DeviceRepository { get; set; }
		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).NotNull();
			this.RuleFor(x => x.DeviceId).Must(this.BeValidDevice).When(x => x ?.DeviceId != null).WithMessage("Invalid reference");
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

		private bool BeValidDevice(int id)
		{
			return this.DeviceRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>a28086332d1eb4a1a62e740531cbd531</Hash>
</Codenesium>*/