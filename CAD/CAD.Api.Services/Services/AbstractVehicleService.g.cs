using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleRepository VehicleRepository { get; private set; }

		protected IApiVehicleServerRequestModelValidator VehicleModelValidator { get; private set; }

		protected IDALVehicleMapper DalVehicleMapper { get; private set; }

		protected IDALVehicleCapabilittyMapper DalVehicleCapabilittyMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleRepository vehicleRepository,
			IApiVehicleServerRequestModelValidator vehicleModelValidator,
			IDALVehicleMapper dalVehicleMapper,
			IDALVehicleCapabilittyMapper dalVehicleCapabilittyMapper)
			: base()
		{
			this.VehicleRepository = vehicleRepository;
			this.VehicleModelValidator = vehicleModelValidator;
			this.DalVehicleMapper = dalVehicleMapper;
			this.DalVehicleCapabilittyMapper = dalVehicleCapabilittyMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Vehicle> records = await this.VehicleRepository.All(limit, offset, query);

			return this.DalVehicleMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleServerResponseModel> Get(int id)
		{
			Vehicle record = await this.VehicleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleServerResponseModel>> Create(
			ApiVehicleServerRequestModel model)
		{
			CreateResponse<ApiVehicleServerResponseModel> response = ValidationResponseFactory<ApiVehicleServerResponseModel>.CreateResponse(await this.VehicleModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Vehicle record = this.DalVehicleMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleRepository.Create(record);

				response.SetRecord(this.DalVehicleMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleServerResponseModel>> Update(
			int id,
			ApiVehicleServerRequestModel model)
		{
			var validationResult = await this.VehicleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Vehicle record = this.DalVehicleMapper.MapModelToEntity(id, model);
				await this.VehicleRepository.Update(record);

				record = await this.VehicleRepository.Get(id);

				ApiVehicleServerResponseModel apiModel = this.DalVehicleMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehicleRepository.Delete(id);

				await this.mediator.Publish(new VehicleDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVehicleCapabilittyServerResponseModel>> VehicleCapabilitiesByVehicleId(int vehicleId, int limit = int.MaxValue, int offset = 0)
		{
			List<VehicleCapabilitty> records = await this.VehicleRepository.VehicleCapabilitiesByVehicleId(vehicleId, limit, offset);

			return this.DalVehicleCapabilittyMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVehicleServerResponseModel>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<Vehicle> records = await this.VehicleRepository.ByOfficerId(officerId, limit, offset);

			return this.DalVehicleMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5d4178985e8d8ed08c3dae2e0b67a10d</Hash>
</Codenesium>*/