using FluentValidation;
using System;

using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service

{
	public class DeviceModelValidatorAbstract: AbstractValidator<DeviceModel>
	{
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,90);
		}

		public virtual void PublicIdRules()
		{
			RuleFor(x => x.PublicId).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>b2e8e411f2ecce83e24e7a3111c96dbf</Hash>
</Codenesium>*/