using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleCapabilityServerRequestModelValidator : AbstractValidator<ApiVehicleCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleCapabilityRepository VehicleCapabilityRepository { get; private set; }

		public AbstractApiVehicleCapabilityServerRequestModelValidator(IVehicleCapabilityRepository vehicleCapabilityRepository)
		{
			this.VehicleCapabilityRepository = vehicleCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleCapabilityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>1871a0dd1cf7cd34f0f9508311e4fa8f</Hash>
</Codenesium>*/