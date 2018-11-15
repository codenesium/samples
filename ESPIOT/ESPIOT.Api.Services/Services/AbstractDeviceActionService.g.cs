using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDeviceActionService : AbstractService
	{
		protected IDeviceActionRepository DeviceActionRepository { get; private set; }

		protected IApiDeviceActionServerRequestModelValidator DeviceActionModelValidator { get; private set; }

		protected IBOLDeviceActionMapper BolDeviceActionMapper { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceActionService(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionServerRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base()
		{
			this.DeviceActionRepository = deviceActionRepository;
			this.DeviceActionModelValidator = deviceActionModelValidator;
			this.BolDeviceActionMapper = bolDeviceActionMapper;
			this.DalDeviceActionMapper = dalDeviceActionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceActionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeviceActionRepository.All(limit, offset);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceActionServerResponseModel> Get(int id)
		{
			var record = await this.DeviceActionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeviceActionServerResponseModel>> Create(
			ApiDeviceActionServerRequestModel model)
		{
			CreateResponse<ApiDeviceActionServerResponseModel> response = ValidationResponseFactory<ApiDeviceActionServerResponseModel>.CreateResponse(await this.DeviceActionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDeviceActionMapper.MapModelToBO(default(int), model);
				var record = await this.DeviceActionRepository.Create(this.DalDeviceActionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(record)));
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
				var bo = this.BolDeviceActionMapper.MapModelToBO(id, model);
				await this.DeviceActionRepository.Update(this.DalDeviceActionMapper.MapBOToEF(bo));

				var record = await this.DeviceActionRepository.Get(id);

				return ValidationResponseFactory<ApiDeviceActionServerResponseModel>.UpdateResponse(this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiDeviceActionServerResponseModel>> ByDeviceId(int deviceId, int limit = 0, int offset = int.MaxValue)
		{
			List<DeviceAction> records = await this.DeviceActionRepository.ByDeviceId(deviceId, limit, offset);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>69ed65172ec3108245c5b28acbc04165</Hash>
</Codenesium>*/