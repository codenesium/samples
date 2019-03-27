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
	public abstract class AbstractApiVehicleCapabilitiesServerRequestModelValidator : AbstractValidator<ApiVehicleCapabilitiesServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleCapabilitiesRepository VehicleCapabilitiesRepository { get; private set; }

		public AbstractApiVehicleCapabilitiesServerRequestModelValidator(IVehicleCapabilitiesRepository vehicleCapabilitiesRepository)
		{
			this.VehicleCapabilitiesRepository = vehicleCapabilitiesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleCapabilitiesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void VehicleCapabilityIdRules()
		{
			this.RuleFor(x => x.VehicleCapabilityId).MustAsync(this.BeValidVehCapabilityByVehicleCapabilityId).When(x => !x?.VehicleCapabilityId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void VehicleIdRules()
		{
			this.RuleFor(x => x.VehicleId).MustAsync(this.BeValidVehicleByVehicleId).When(x => !x?.VehicleId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidVehCapabilityByVehicleCapabilityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleCapabilitiesRepository.VehCapabilityByVehicleCapabilityId(id);

			return record != null;
		}

		protected async Task<bool> BeValidVehicleByVehicleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleCapabilitiesRepository.VehicleByVehicleId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>07b155b003555201455cfd98786e0abf</Hash>
</Codenesium>*/