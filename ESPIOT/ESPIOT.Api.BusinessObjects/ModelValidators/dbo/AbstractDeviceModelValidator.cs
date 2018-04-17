using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

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

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}
	}
}

/*<Codenesium>
    <Hash>85041d6c09322b2cfea59fd4d781ea17</Hash>
</Codenesium>*/