using Codenesium.DataConversionExtensions;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDeviceActionService : AbstractService
	{
		private IDeviceActionRepository deviceActionRepository;

		private IApiDeviceActionRequestModelValidator deviceActionModelValidator;

		private IBOLDeviceActionMapper bolDeviceActionMapper;

		private IDALDeviceActionMapper dalDeviceActionMapper;

		private ILogger logger;

		public AbstractDeviceActionService(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base()
		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.bolDeviceActionMapper = bolDeviceActionMapper;
			this.dalDeviceActionMapper = dalDeviceActionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.deviceActionRepository.All(limit, offset);

			return this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceActionResponseModel> Get(int id)
		{
			var record = await this.deviceActionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model)
		{
			CreateResponse<ApiDeviceActionResponseModel> response = new CreateResponse<ApiDeviceActionResponseModel>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDeviceActionMapper.MapModelToBO(default(int), model);
				var record = await this.deviceActionRepository.Create(this.dalDeviceActionMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeviceActionResponseModel>> Update(
			int id,
			ApiDeviceActionRequestModel model)
		{
			var validationResult = await this.deviceActionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolDeviceActionMapper.MapModelToBO(id, model);
				await this.deviceActionRepository.Update(this.dalDeviceActionMapper.MapBOToEF(bo));

				var record = await this.deviceActionRepository.Get(id);

				return new UpdateResponse<ApiDeviceActionResponseModel>(this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeviceActionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.deviceActionRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId)
		{
			List<DeviceAction> records = await this.deviceActionRepository.ByDeviceId(deviceId);

			return this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8b85263c7a9da8c52b7c091bfd80511d</Hash>
</Codenesium>*/