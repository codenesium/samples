using Codenesium.DataConversionExtensions.AspNetCore;
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

		public virtual void PublicIdRules()
		{
			RuleFor(x => x.PublicId).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,90);
		}
	}
}

/*<Codenesium>
    <Hash>ab8110314c4432eb475ba31249c84219</Hash>
</Codenesium>*/