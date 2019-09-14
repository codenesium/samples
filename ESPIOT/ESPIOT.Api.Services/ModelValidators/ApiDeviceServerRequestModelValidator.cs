using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceServerRequestModelValidator : AbstractValidator<ApiDeviceServerRequestModel>, IApiDeviceServerRequestModelValidator
	{
		private int existingRecordId;

		protected IDeviceRepository DeviceRepository { get; private set; }

		public ApiDeviceServerRequestModelValidator(IDeviceRepository deviceRepository)
		{
			this.DeviceRepository = deviceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceServerRequestModel model)
		{
			this.DateOfLastPingRules();
			this.IsActiveRules();
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model)
		{
			this.DateOfLastPingRules();
			this.IsActiveRules();
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void DateOfLastPingRules()
		{
		}

		public virtual void IsActiveRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByPublicId).When(x => (!x?.PublicId.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiDeviceServerRequestModel.PublicId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByPublicId(ApiDeviceServerRequestModel model,  CancellationToken cancellationToken)
		{
			Device record = await this.DeviceRepository.ByPublicId(model.PublicId);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
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
    <Hash>cd7939170c0aa06888b4522b78d4fc21</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/