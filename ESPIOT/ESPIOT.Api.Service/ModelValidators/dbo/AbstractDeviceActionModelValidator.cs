using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Service

{
	public abstract class AbstractDeviceActionModelValidator: AbstractValidator<DeviceActionModel>
	{
		public new ValidationResult Validate(DeviceActionModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DeviceActionModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDeviceRepository DeviceRepository {get; set;}
		public virtual void DeviceIdRules()
		{
			RuleFor(x => x.DeviceId).NotNull();
			RuleFor(x => x.DeviceId).Must(BeValidDevice).When(x => x ?.DeviceId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,90);
		}

		public virtual void @ValueRules()
		{
			RuleFor(x => x.@Value).NotNull();
			RuleFor(x => x.@Value).Length(0,4000);
		}

		private bool BeValidDevice(int id)
		{
			return this.DeviceRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ae86588f75e789bac8b84afa95cfb1d3</Hash>
</Codenesium>*/