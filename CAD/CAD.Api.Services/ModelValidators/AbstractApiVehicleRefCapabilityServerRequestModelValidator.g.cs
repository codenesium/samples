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
	public abstract class AbstractApiVehicleRefCapabilityServerRequestModelValidator : AbstractValidator<ApiVehicleRefCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleRefCapabilityRepository VehicleRefCapabilityRepository { get; private set; }

		public AbstractApiVehicleRefCapabilityServerRequestModelValidator(IVehicleRefCapabilityRepository vehicleRefCapabilityRepository)
		{
			this.VehicleRefCapabilityRepository = vehicleRefCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleRefCapabilityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void VehicleCapabilityIdRules()
		{
			this.RuleFor(x => x.VehicleCapabilityId).MustAsync(this.BeValidVehicleCapabilityByVehicleCapabilityId).When(x => !x?.VehicleCapabilityId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void VehicleIdRules()
		{
			this.RuleFor(x => x.VehicleId).MustAsync(this.BeValidVehicleByVehicleId).When(x => !x?.VehicleId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidVehicleCapabilityByVehicleCapabilityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleRefCapabilityRepository.VehicleCapabilityByVehicleCapabilityId(id);

			return record != null;
		}

		protected async Task<bool> BeValidVehicleByVehicleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleRefCapabilityRepository.VehicleByVehicleId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>5c0299396935bae0a774b75c5138f693</Hash>
</Codenesium>*/