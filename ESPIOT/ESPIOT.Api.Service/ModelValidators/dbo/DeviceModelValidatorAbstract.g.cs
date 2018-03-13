using FluentValidation;
using System;

using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service

{
	public class DeviceModelValidatorAbstract: AbstractValidator<DeviceModel>
	{
		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

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
    <Hash>ed7d2ccb9caac5f9bca42b55dd4c6b75</Hash>
</Codenesium>*/