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

		public IDeviceRepository DeviceRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 90);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull();
			this.RuleFor(x => x).Must(this.BeUniquePublicId).When(x => x ?.PublicId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceModel.PublicId));
		}

		private bool BeUniquePublicId(ApiDeviceModel model)
		{
			return this.DeviceRepository.PublicId(model.PublicId) == null;
		}
	}
}

/*<Codenesium>
    <Hash>a6782667265c1c7f0dd33f3676dfe254</Hash>
</Codenesium>*/