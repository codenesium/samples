using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleRefCapabilityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleRefCapabilityRepository VehicleRefCapabilityRepository { get; private set; }

		protected IApiVehicleRefCapabilityServerRequestModelValidator VehicleRefCapabilityModelValidator { get; private set; }

		protected IDALVehicleRefCapabilityMapper DalVehicleRefCapabilityMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleRefCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleRefCapabilityRepository vehicleRefCapabilityRepository,
			IApiVehicleRefCapabilityServerRequestModelValidator vehicleRefCapabilityModelValidator,
			IDALVehicleRefCapabilityMapper dalVehicleRefCapabilityMapper)
			: base()
		{
			this.VehicleRefCapabilityRepository = vehicleRefCapabilityRepository;
			this.VehicleRefCapabilityModelValidator = vehicleRefCapabilityModelValidator;
			this.DalVehicleRefCapabilityMapper = dalVehicleRefCapabilityMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleRefCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehicleRefCapability> records = await this.VehicleRefCapabilityRepository.All(limit, offset, query);

			return this.DalVehicleRefCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleRefCapabilityServerResponseModel> Get(int id)
		{
			VehicleRefCapability record = await this.VehicleRefCapabilityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleRefCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleRefCapabilityServerResponseModel>> Create(
			ApiVehicleRefCapabilityServerRequestModel model)
		{
			CreateResponse<ApiVehicleRefCapabilityServerResponseModel> response = ValidationResponseFactory<ApiVehicleRefCapabilityServerResponseModel>.CreateResponse(await this.VehicleRefCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehicleRefCapability record = this.DalVehicleRefCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleRefCapabilityRepository.Create(record);

				response.SetRecord(this.DalVehicleRefCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleRefCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleRefCapabilityServerResponseModel>> Update(
			int id,
			ApiVehicleRefCapabilityServerRequestModel model)
		{
			var validationResult = await this.VehicleRefCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VehicleRefCapability record = this.DalVehicleRefCapabilityMapper.MapModelToEntity(id, model);
				await this.VehicleRefCapabilityRepository.Update(record);

				record = await this.VehicleRefCapabilityRepository.Get(id);

				ApiVehicleRefCapabilityServerResponseModel apiModel = this.DalVehicleRefCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleRefCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleRefCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleRefCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleRefCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehicleRefCapabilityRepository.Delete(id);

				await this.mediator.Publish(new VehicleRefCapabilityDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21acef02e43205ac2807eefcd86234cd</Hash>
</Codenesium>*/