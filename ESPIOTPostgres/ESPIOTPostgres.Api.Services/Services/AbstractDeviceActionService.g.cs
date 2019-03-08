using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public abstract class AbstractDeviceActionService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IDeviceActionRepository DeviceActionRepository { get; private set; }

		protected IApiDeviceActionServerRequestModelValidator DeviceActionModelValidator { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceActionService(
			ILogger logger,
			MediatR.IMediator mediator,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionServerRequestModelValidator deviceActionModelValidator,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base()
		{
			this.DeviceActionRepository = deviceActionRepository;
			this.DeviceActionModelValidator = deviceActionModelValidator;
			this.DalDeviceActionMapper = dalDeviceActionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDeviceActionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<DeviceAction> records = await this.DeviceActionRepository.All(limit, offset, query);

			return this.DalDeviceActionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDeviceActionServerResponseModel> Get(int id)
		{
			DeviceAction record = await this.DeviceActionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDeviceActionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDeviceActionServerResponseModel>> Create(
			ApiDeviceActionServerRequestModel model)
		{
			CreateResponse<ApiDeviceActionServerResponseModel> response = ValidationResponseFactory<ApiDeviceActionServerResponseModel>.CreateResponse(await this.DeviceActionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				DeviceAction record = this.DalDeviceActionMapper.MapModelToEntity(default(int), model);
				record = await this.DeviceActionRepository.Create(record);

				response.SetRecord(this.DalDeviceActionMapper.MapEntityToModel(record));
				await this.mediator.Publish(new DeviceActionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeviceActionServerResponseModel>> Update(
			int id,
			ApiDeviceActionServerRequestModel model)
		{
			var validationResult = await this.DeviceActionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				DeviceAction record = this.DalDeviceActionMapper.MapModelToEntity(id, model);
				await this.DeviceActionRepository.Update(record);

				record = await this.DeviceActionRepository.Get(id);

				ApiDeviceActionServerResponseModel apiModel = this.DalDeviceActionMapper.MapEntityToModel(record);
				await this.mediator.Publish(new DeviceActionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDeviceActionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDeviceActionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DeviceActionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.DeviceActionRepository.Delete(id);

				await this.mediator.Publish(new DeviceActionDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiDeviceActionServerResponseModel>> ByDeviceId(int deviceId, int limit = 0, int offset = int.MaxValue)
		{
			List<DeviceAction> records = await this.DeviceActionRepository.ByDeviceId(deviceId, limit, offset);

			return this.DalDeviceActionMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>858c0f19e717deb61d5f1f48cc2efa3d</Hash>
</Codenesium>*/