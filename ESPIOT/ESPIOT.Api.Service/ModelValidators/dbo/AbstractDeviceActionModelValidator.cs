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

		public bool BeValidDevice(int id)
		{
			Response response = new Response();

			this.DeviceRepository.GetById(id,response);
			return response.Devices.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>0bd485001a8bb9eca021b7e6b88dfc2f</Hash>
</Codenesium>*/