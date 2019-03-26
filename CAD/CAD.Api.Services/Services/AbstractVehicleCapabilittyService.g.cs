using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleCapabilittyService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleCapabilittyRepository VehicleCapabilittyRepository { get; private set; }

		protected IApiVehicleCapabilittyServerRequestModelValidator VehicleCapabilittyModelValidator { get; private set; }

		protected IDALVehicleCapabilittyMapper DalVehicleCapabilittyMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleCapabilittyService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleCapabilittyRepository vehicleCapabilittyRepository,
			IApiVehicleCapabilittyServerRequestModelValidator vehicleCapabilittyModelValidator,
			IDALVehicleCapabilittyMapper dalVehicleCapabilittyMapper)
			: base()
		{
			this.VehicleCapabilittyRepository = vehicleCapabilittyRepository;
			this.VehicleCapabilittyModelValidator = vehicleCapabilittyModelValidator;
			this.DalVehicleCapabilittyMapper = dalVehicleCapabilittyMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleCapabilittyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehicleCapabilitty> records = await this.VehicleCapabilittyRepository.All(limit, offset, query);

			return this.DalVehicleCapabilittyMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleCapabilittyServerResponseModel> Get(int vehicleId)
		{
			VehicleCapabilitty record = await this.VehicleCapabilittyRepository.Get(vehicleId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleCapabilittyMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleCapabilittyServerResponseModel>> Create(
			ApiVehicleCapabilittyServerRequestModel model)
		{
			CreateResponse<ApiVehicleCapabilittyServerResponseModel> response = ValidationResponseFactory<ApiVehicleCapabilittyServerResponseModel>.CreateResponse(await this.VehicleCapabilittyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehicleCapabilitty record = this.DalVehicleCapabilittyMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleCapabilittyRepository.Create(record);

				response.SetRecord(this.DalVehicleCapabilittyMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleCapabilittyCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleCapabilittyServerResponseModel>> Update(
			int vehicleId,
			ApiVehicleCapabilittyServerRequestModel model)
		{
			var validationResult = await this.VehicleCapabilittyModelValidator.ValidateUpdateAsync(vehicleId, model);

			if (validationResult.IsValid)
			{
				VehicleCapabilitty record = this.DalVehicleCapabilittyMapper.MapModelToEntity(vehicleId, model);
				await this.VehicleCapabilittyRepository.Update(record);

				record = await this.VehicleCapabilittyRepository.Get(vehicleId);

				ApiVehicleCapabilittyServerResponseModel apiModel = this.DalVehicleCapabilittyMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleCapabilittyUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleCapabilittyServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleCapabilittyServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int vehicleId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleCapabilittyModelValidator.ValidateDeleteAsync(vehicleId));

			if (response.Success)
			{
				await this.VehicleCapabilittyRepository.Delete(vehicleId);

				await this.mediator.Publish(new VehicleCapabilittyDeletedNotification(vehicleId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4ebed2dc181222092dbba18405d11985</Hash>
</Codenesium>*/