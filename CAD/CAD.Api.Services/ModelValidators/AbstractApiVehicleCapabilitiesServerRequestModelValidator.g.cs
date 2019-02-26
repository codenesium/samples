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
		}

		protected async Task<bool> BeValidVehicleByVehicleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VehicleCapabilitiesRepository.VehicleByVehicleId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8049ea8d48a2e5fd32476bd2842cb70a</Hash>
</Codenesium>*/