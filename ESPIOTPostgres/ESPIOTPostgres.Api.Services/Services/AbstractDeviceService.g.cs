using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Services
{
	public abstract class AbstractDeviceService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IDeviceRepository DeviceRepository { get; private set; }

		protected IApiDeviceServerRequestModelValidator DeviceModelValidator { get; private set; }

		protected IDALDeviceMapper DalDeviceMapper { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceService(
			ILogger logger,
			MediatR.IMediator mediator,
			IDeviceRepository deviceRepository,
			IApiDeviceServerRequestModelValidator deviceModelValidator,
			IDALDeviceMapper dalDeviceMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base()
		{
			this.DeviceRepository = deviceRepository;
			this.DeviceModelValidator = deviceModelValidator;
			this.DalDeviceMapper = dalDeviceMapper;
			this.DalDeviceActionMapper = dalDeviceActionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDeviceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Device> records = await this.DeviceRepository.All(limit, offset, query);

			return this.DalDeviceMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDeviceServerResponseModel> Get(int id)
		{
			Device record = await this.DeviceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDeviceMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDeviceServerResponseModel>> Create(
			ApiDeviceServerRequestModel model)
		{
			CreateResponse<ApiDeviceServerResponseModel> response = ValidationResponseFactory<ApiDeviceServerResponseModel>.CreateResponse(await this.DeviceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Device record = this.DalDeviceMapper.MapModelToEntity(default(int), model);
				record = await this.DeviceRepository.Create(record);

				response.SetRecord(this.DalDeviceMapper.MapEntityToModel(record));
				await this.mediator.Publish(new DeviceCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeviceServerResponseModel>> Update(
			int id,
			ApiDeviceServerRequestModel model)
		{
			var validationResult = await this.DeviceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Device record = this.DalDeviceMapper.MapModelToEntity(id, model);
				await this.DeviceRepository.Update(record);

				record = await this.DeviceRepository.Get(id);

				ApiDeviceServerResponseModel apiModel = this.DalDeviceMapper.MapEntityToModel(record);
				await this.mediator.Publish(new DeviceUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDeviceServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDeviceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DeviceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.DeviceRepository.Delete(id);

				await this.mediator.Publish(new DeviceDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiDeviceServerResponseModel> ByPublicId(Guid publicId)
		{
			Device record = await this.DeviceRepository.ByPublicId(publicId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDeviceMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiDeviceActionServerResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			List<DeviceAction> records = await this.DeviceRepository.DeviceActionsByDeviceId(deviceId, limit, offset);

			return this.DalDeviceActionMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>947936d3668ba797be3d0d2d4701cbff</Hash>
</Codenesium>*/