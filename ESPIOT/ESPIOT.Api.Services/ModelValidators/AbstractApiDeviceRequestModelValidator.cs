using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.Services

{
	public abstract class AbstractApiDeviceRequestModelValidator: AbstractValidator<ApiDeviceRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiDeviceRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceRequestModel model, int id)
		{
			this.existingRecordId = id;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetPublicId).When(x => x ?.PublicId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceRequestModel.PublicId));
		}

		private async Task<bool> BeUniqueGetPublicId(ApiDeviceRequestModel model,  CancellationToken cancellationToken)
		{
			Device record = await this.DeviceRepository.GetPublicId(model.PublicId);

			if(record == null || record.Id == this.existingRecordId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>0978930a3d9675028b6f243b05989b88</Hash>
</Codenesium>*/