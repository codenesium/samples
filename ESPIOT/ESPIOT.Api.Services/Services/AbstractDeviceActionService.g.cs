using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractDeviceActionService: AbstractService
	{
		private IDeviceActionRepository deviceActionRepository;
		private IApiDeviceActionRequestModelValidator deviceActionModelValidator;
		private IBOLDeviceActionMapper BOLDeviceActionMapper;
		private IDALDeviceActionMapper DALDeviceActionMapper;
		private ILogger logger;

		public AbstractDeviceActionService(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper boldeviceActionMapper,
			IDALDeviceActionMapper daldeviceActionMapper)
			: base()

		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.BOLDeviceActionMapper = boldeviceActionMapper;
			this.DALDeviceActionMapper = daldeviceActionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.deviceActionRepository.All(skip, take, orderClause);

			return this.BOLDeviceActionMapper.MapBOToModel(this.DALDeviceActionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceActionResponseModel> Get(int id)
		{
			var record = await deviceActionRepository.Get(id);

			return this.BOLDeviceActionMapper.MapBOToModel(this.DALDeviceActionMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model)
		{
			CreateResponse<ApiDeviceActionResponseModel> response = new CreateResponse<ApiDeviceActionResponseModel>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLDeviceActionMapper.MapModelToBO(default (int), model);
				var record = await this.deviceActionRepository.Create(this.DALDeviceActionMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLDeviceActionMapper.MapBOToModel(this.DALDeviceActionMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDeviceActionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.deviceActionModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLDeviceActionMapper.MapModelToBO(id, model);
				await this.deviceActionRepository.Update(this.DALDeviceActionMapper.MapBOToEF(bo));
			}

			return response;
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

		public async Task<List<ApiDeviceActionResponseModel>> GetDeviceId(int deviceId)
		{
			List<DeviceAction> records = await this.deviceActionRepository.GetDeviceId(deviceId);

			return this.BOLDeviceActionMapper.MapBOToModel(this.DALDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>515d8a48da37947d526dbf4ef8fb7a0a</Hash>
</Codenesium>*/