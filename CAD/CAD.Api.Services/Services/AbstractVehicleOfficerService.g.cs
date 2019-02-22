using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractVehicleOfficerService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVehicleOfficerRepository VehicleOfficerRepository { get; private set; }

		protected IApiVehicleOfficerServerRequestModelValidator VehicleOfficerModelValidator { get; private set; }

		protected IDALVehicleOfficerMapper DalVehicleOfficerMapper { get; private set; }

		private ILogger logger;

		public AbstractVehicleOfficerService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVehicleOfficerRepository vehicleOfficerRepository,
			IApiVehicleOfficerServerRequestModelValidator vehicleOfficerModelValidator,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base()
		{
			this.VehicleOfficerRepository = vehicleOfficerRepository;
			this.VehicleOfficerModelValidator = vehicleOfficerModelValidator;
			this.DalVehicleOfficerMapper = dalVehicleOfficerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVehicleOfficerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VehicleOfficer> records = await this.VehicleOfficerRepository.All(limit, offset, query);

			return this.DalVehicleOfficerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVehicleOfficerServerResponseModel> Get(int id)
		{
			VehicleOfficer record = await this.VehicleOfficerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVehicleOfficerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVehicleOfficerServerResponseModel>> Create(
			ApiVehicleOfficerServerRequestModel model)
		{
			CreateResponse<ApiVehicleOfficerServerResponseModel> response = ValidationResponseFactory<ApiVehicleOfficerServerResponseModel>.CreateResponse(await this.VehicleOfficerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VehicleOfficer record = this.DalVehicleOfficerMapper.MapModelToEntity(default(int), model);
				record = await this.VehicleOfficerRepository.Create(record);

				response.SetRecord(this.DalVehicleOfficerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VehicleOfficerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVehicleOfficerServerResponseModel>> Update(
			int id,
			ApiVehicleOfficerServerRequestModel model)
		{
			var validationResult = await this.VehicleOfficerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				VehicleOfficer record = this.DalVehicleOfficerMapper.MapModelToEntity(id, model);
				await this.VehicleOfficerRepository.Update(record);

				record = await this.VehicleOfficerRepository.Get(id);

				ApiVehicleOfficerServerResponseModel apiModel = this.DalVehicleOfficerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VehicleOfficerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVehicleOfficerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVehicleOfficerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VehicleOfficerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VehicleOfficerRepository.Delete(id);

				await this.mediator.Publish(new VehicleOfficerDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>314f0d84c106cbb66f5625d98184b262</Hash>
</Codenesium>*/