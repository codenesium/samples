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
	public class ApiDeviceActionServerRequestModelValidator : AbstractValidator<ApiDeviceActionServerRequestModel>, IApiDeviceActionServerRequestModelValidator
	{
		private int existingRecordId;

		protected IDeviceActionRepository DeviceActionRepository { get; private set; }

		public ApiDeviceActionServerRequestModelValidator(IDeviceActionRepository deviceActionRepository)
		{
			this.DeviceActionRepository = deviceActionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDeviceActionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionServerRequestModel model)
		{
			this.ActionRules();
			this.DeviceIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionServerRequestModel model)
		{
			this.ActionRules();
			this.DeviceIdRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void ActionRules()
		{
			this.RuleFor(x => x.Action).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Action).Length(0, 4000).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DeviceIdRules()
		{
			this.RuleFor(x => x.DeviceId).MustAsync(this.BeValidDeviceByDeviceId).When(x => !x?.DeviceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidDeviceByDeviceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DeviceActionRepository.DeviceByDeviceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>78436887c0d15178b7e0cb46dacd62d3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/