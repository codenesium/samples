using FluentValidation;
using System;

using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service

{
	public class DeviceActionModelValidatorAbstract: AbstractValidator<DeviceActionModel>
	{
		public DeviceRepository DeviceRepository {get; set;}

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
    <Hash>ea6ab61c816186c19a9b0340b91433a0</Hash>
</Codenesium>*/