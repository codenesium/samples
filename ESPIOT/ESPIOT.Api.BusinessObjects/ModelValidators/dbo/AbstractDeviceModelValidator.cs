using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

{
	public abstract class AbstractApiDeviceModelValidator: AbstractValidator<ApiDeviceModel>
	{
		public new ValidationResult Validate(ApiDeviceModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>65b09de6a9255005ba22ddbe17c6570f</Hash>
</Codenesium>*/