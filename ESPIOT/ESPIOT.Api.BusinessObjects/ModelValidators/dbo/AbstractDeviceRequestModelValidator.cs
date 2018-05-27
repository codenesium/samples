using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects

{
	public abstract class AbstractApiDeviceRequestModelValidator: AbstractValidator<ApiDeviceRequestModel>
	{
		public new ValidationResult Validate(ApiDeviceRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceRequestModel model)
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
			this.RuleFor(x => x).MustAsync(this.BeUniquePublicId).When(x => x ?.PublicId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceRequestModel.PublicId));
		}

		private async Task<bool> BeUniquePublicId(ApiDeviceRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.DeviceRepository.PublicId(model.PublicId);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>4fbcd06c16a2e063f2a3d1a3339af487</Hash>
</Codenesium>*/