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
	public abstract class AbstractApiVehicleCapabilittyServerRequestModelValidator : AbstractValidator<ApiVehicleCapabilittyServerRequestModel>
	{
		private int existingRecordId;

		protected IVehicleCapabilittyRepository VehicleCapabilittyRepository { get; private set; }

		public AbstractApiVehicleCapabilittyServerRequestModelValidator(IVehicleCapabilittyRepository vehicleCapabilittyRepository)
		{
			this.VehicleCapabilittyRepository = vehicleCapabilittyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVehicleCapabilittyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void VehicleCapabilityIdRules()
		{
		}

		protected async Task<bool> BeValidVehicleByVehicleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleCapabilittyRepository.VehicleByVehicleId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>278a6c2457fcf955c4fc36d6876a7fa1</Hash>
</Codenesium>*/