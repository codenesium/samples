using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehCapabilityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehCapabilityRepository VehCapabilityRepository { get; private set; }

		protected IApiVehCapabilityServerRequestModelValidator VehCapabilityModelValidator { get; private set; }

		protected IDALVehCapabilityMapper DalVehCapabilityMapper { get; private set; }

		protected IDALVehicleCapabilitiesMapper DalVehicleCapabilitiesMapper { get; private set; }

		private ILogger logger;

		public AbstractVehCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehCapabilityRepository vehCapabilityRepository,
			IApiVehCapabilityServerRequestModelValidator vehCapabilityModelValidator,
			IDALVehCapabilityMapper dalVehCapabilityMapper,
			IDALVehicleCapabilitiesMapper dalVehicleCapabilitiesMapper)
			: base()
		{
			this.VehCapabilityRepository = vehCapabilityRepository;
			this.VehCapabilityModelValidator = vehCapabilityModelValidator;
			this.DalVehCapabilityMapper = dalVehCapabilityMapper;
			this.DalVehicleCapabilitiesMapper = dalVehicleCapabilitiesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehCapability> records = await this.VehCapabilityRepository.All(limit, offset, query);

			return this.DalVehCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehCapabilityServerResponseModel> Get(int id)
		{
			VehCapability record = await this.VehCapabilityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehCapabilityServerResponseModel>> Create(
			ApiVehCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehCapabilityServerResponseModel> response = ValidationResponseFactory<ApiVehCapabilityServerResponseModel>.CreateResponse(await this.VehCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehCapability record = this.DalVehCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.VehCapabilityRepository.Create(record);

				response.SetRecord(this.DalVehCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehCapabilityServerResponseModel>> Update(
			int id,
			ApiVehCapabilityServerRequestModel model)
		{
			var validationResult = await this.VehCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VehCapability record = this.DalVehCapabilityMapper.MapModelToEntity(id, model);
				await this.VehCapabilityRepository.Update(record);

				record = await this.VehCapabilityRepository.Get(id);

				ApiVehCapabilityServerResponseModel apiModel = this.DalVehCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehCapabilityRepository.Delete(id);

				await this.mediator.Publish(new VehCapabilityDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVehicleCapabilitiesServerResponseModel>> VehicleCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0)
		{
			List<VehicleCapabilities> records = await this.VehCapabilityRepository.VehicleCapabilitiesByVehicleCapabilityId(vehicleCapabilityId, limit, offset);

			return this.DalVehicleCapabilitiesMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d190fad6cbb0a847564e3e44d09d6440</Hash>
</Codenesium>*/