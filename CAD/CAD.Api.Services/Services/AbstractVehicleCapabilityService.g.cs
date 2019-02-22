using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleCapabilityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleCapabilityRepository VehicleCapabilityRepository { get; private set; }

		protected IApiVehicleCapabilityServerRequestModelValidator VehicleCapabilityModelValidator { get; private set; }

		protected IDALVehicleCapabilityMapper DalVehicleCapabilityMapper { get; private set; }

		protected IDALVehicleRefCapabilityMapper DalVehicleRefCapabilityMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleCapabilityRepository vehicleCapabilityRepository,
			IApiVehicleCapabilityServerRequestModelValidator vehicleCapabilityModelValidator,
			IDALVehicleCapabilityMapper dalVehicleCapabilityMapper,
			IDALVehicleRefCapabilityMapper dalVehicleRefCapabilityMapper)
			: base()
		{
			this.VehicleCapabilityRepository = vehicleCapabilityRepository;
			this.VehicleCapabilityModelValidator = vehicleCapabilityModelValidator;
			this.DalVehicleCapabilityMapper = dalVehicleCapabilityMapper;
			this.DalVehicleRefCapabilityMapper = dalVehicleRefCapabilityMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehicleCapability> records = await this.VehicleCapabilityRepository.All(limit, offset, query);

			return this.DalVehicleCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleCapabilityServerResponseModel> Get(int id)
		{
			VehicleCapability record = await this.VehicleCapabilityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleCapabilityServerResponseModel>> Create(
			ApiVehicleCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilityServerResponseModel> response = ValidationResponseFactory<ApiVehicleCapabilityServerResponseModel>.CreateResponse(await this.VehicleCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehicleCapability record = this.DalVehicleCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleCapabilityRepository.Create(record);

				response.SetRecord(this.DalVehicleCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleCapabilityServerResponseModel>> Update(
			int id,
			ApiVehicleCapabilityServerRequestModel model)
		{
			var validationResult = await this.VehicleCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VehicleCapability record = this.DalVehicleCapabilityMapper.MapModelToEntity(id, model);
				await this.VehicleCapabilityRepository.Update(record);

				record = await this.VehicleCapabilityRepository.Get(id);

				ApiVehicleCapabilityServerResponseModel apiModel = this.DalVehicleCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehicleCapabilityRepository.Delete(id);

				await this.mediator.Publish(new VehicleCapabilityDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVehicleRefCapabilityServerResponseModel>> VehicleRefCapabilitiesByVehicleCapabilityId(int vehicleCapabilityId, int limit = int.MaxValue, int offset = 0)
		{
			List<VehicleRefCapability> records = await this.VehicleCapabilityRepository.VehicleRefCapabilitiesByVehicleCapabilityId(vehicleCapabilityId, limit, offset);

			return this.DalVehicleRefCapabilityMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>6b8547789f359cf8578b2f4bdf26b5aa</Hash>
</Codenesium>*/