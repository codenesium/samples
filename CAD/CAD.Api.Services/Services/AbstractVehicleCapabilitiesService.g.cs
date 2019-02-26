using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleCapabilitiesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleCapabilitiesRepository VehicleCapabilitiesRepository { get; private set; }

		protected IApiVehicleCapabilitiesServerRequestModelValidator VehicleCapabilitiesModelValidator { get; private set; }

		protected IDALVehicleCapabilitiesMapper DalVehicleCapabilitiesMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleCapabilitiesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleCapabilitiesRepository vehicleCapabilitiesRepository,
			IApiVehicleCapabilitiesServerRequestModelValidator vehicleCapabilitiesModelValidator,
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper)
			: base()
		{
			this.VehicleCapabilitiesRepository = vehicleCapabilitiesRepository;
			this.VehicleCapabilitiesModelValidator = vehicleCapabilitiesModelValidator;
			this.DalVehicleCapabilitiesMapper = dalVehicleCapabilitiesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleCapabilitiesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehicleCapabilities> records = await this.VehicleCapabilitiesRepository.All(limit, offset, query);

			return this.DalVehicleCapabilitiesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleCapabilitiesServerResponseModel> Get(int vehicleId)
		{
			VehicleCapabilities record = await this.VehicleCapabilitiesRepository.Get(vehicleId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleCapabilitiesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleCapabilitiesServerResponseModel>> Create(
			ApiVehicleCapabilitiesServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilitiesServerResponseModel> response = ValidationResponseFactory<ApiVehicleCapabilitiesServerResponseModel>.CreateResponse(await this.VehicleCapabilitiesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehicleCapabilities record = this.DalVehicleCapabilitiesMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleCapabilitiesRepository.Create(record);

				response.SetRecord(this.DalVehicleCapabilitiesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleCapabilitiesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleCapabilitiesServerResponseModel>> Update(
			int vehicleId,
			ApiVehicleCapabilitiesServerRequestModel model)
		{
			var validationResult = await this.VehicleCapabilitiesModelValidator.ValidateUpdateAsync(vehicleId, model);

			if (validationResult.IsValid)
			{
				VehicleCapabilities record = this.DalVehicleCapabilitiesMapper.MapModelToEntity(vehicleId, model);
				await this.VehicleCapabilitiesRepository.Update(record);

				record = await this.VehicleCapabilitiesRepository.Get(vehicleId);

				ApiVehicleCapabilitiesServerResponseModel apiModel = this.DalVehicleCapabilitiesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleCapabilitiesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleCapabilitiesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleCapabilitiesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int vehicleId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleCapabilitiesModelValidator.ValidateDeleteAsync(vehicleId));

			if (response.Success)
			{
				await this.VehicleCapabilitiesRepository.Delete(vehicleId);

				await this.mediator.Publish(new VehicleCapabilitiesDeletedNotification(vehicleId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a0686103d16db85ebc0cb2a3182fe86e</Hash>
</Codenesium>*/