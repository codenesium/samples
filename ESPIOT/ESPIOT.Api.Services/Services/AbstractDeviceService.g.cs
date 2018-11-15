using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDeviceService : AbstractService
	{
		protected IDeviceRepository DeviceRepository { get; private set; }

		protected IApiDeviceServerRequestModelValidator DeviceModelValidator { get; private set; }

		protected IBOLDeviceMapper BolDeviceMapper { get; private set; }

		protected IDALDeviceMapper DalDeviceMapper { get; private set; }

		protected IBOLDeviceActionMapper BolDeviceActionMapper { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceService(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceServerRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper bolDeviceMapper,
			IDALDeviceMapper dalDeviceMapper,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base()
		{
			this.DeviceRepository = deviceRepository;
			this.DeviceModelValidator = deviceModelValidator;
			this.BolDeviceMapper = bolDeviceMapper;
			this.DalDeviceMapper = dalDeviceMapper;
			this.BolDeviceActionMapper = bolDeviceActionMapper;
			this.DalDeviceActionMapper = dalDeviceActionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeviceRepository.All(limit, offset);

			return this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceServerResponseModel> Get(int id)
		{
			var record = await this.DeviceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeviceServerResponseModel>> Create(
			ApiDeviceServerRequestModel model)
		{
			CreateResponse<ApiDeviceServerResponseModel> response = ValidationResponseFactory<ApiDeviceServerResponseModel>.CreateResponse(await this.DeviceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDeviceMapper.MapModelToBO(default(int), model);
				var record = await this.DeviceRepository.Create(this.DalDeviceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record)));
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
				var bo = this.BolDeviceMapper.MapModelToBO(id, model);
				await this.DeviceRepository.Update(this.DalDeviceMapper.MapBOToEF(bo));

				var record = await this.DeviceRepository.Get(id);

				return ValidationResponseFactory<ApiDeviceServerResponseModel>.UpdateResponse(this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record)));
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
				return this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiDeviceActionServerResponseModel>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			List<DeviceAction> records = await this.DeviceRepository.DeviceActionsByDeviceId(deviceId, limit, offset);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d3c92b091c4bc51982d5423d36f1100c</Hash>
</Codenesium>*/