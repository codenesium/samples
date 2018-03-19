using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service

{
	public abstract class AbstractDeviceModelValidator: AbstractValidator<DeviceModel>
	{
		public new ValidationResult Validate(DeviceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DeviceModel model)
		{
			return await base.ValidateAsync(model);
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
    <Hash>5b2b1e315a372d5c4dfc9bc93ab21049</Hash>
</Codenesium>*/