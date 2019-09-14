using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class VehicleCapabilitiesService : AbstractService, IVehicleCapabilitiesService
	{
		private MediatR.IMediator mediator;

		protected IVehicleCapabilitiesRepository VehicleCapabilitiesRepository { get; private set; }

		protected IApiVehicleCapabilitiesServerRequestModelValidator VehicleCapabilitiesModelValidator { get; private set; }

		protected IDALVehicleCapabilitiesMapper DalVehicleCapabilitiesMapper { get; private set; }

		private ILogger logger;

		public VehicleCapabilitiesService(
			ILogger<IVehicleCapabilitiesService> logger,
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

		public virtual async Task<ApiVehicleCapabilitiesServerResponseModel> Get(int id)
		{
			VehicleCapabilities record = await this.VehicleCapabilitiesRepository.Get(id);

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
			int id,
			ApiVehicleCapabilitiesServerRequestModel model)
		{
			var validationResult = await this.VehicleCapabilitiesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VehicleCapabilities record = this.DalVehicleCapabilitiesMapper.MapModelToEntity(id, model);
				await this.VehicleCapabilitiesRepository.Update(record);

				record = await this.VehicleCapabilitiesRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleCapabilitiesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehicleCapabilitiesRepository.Delete(id);

				await this.mediator.Publish(new VehicleCapabilitiesDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>feabce0630532926f49e61f4f33ae830</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/