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
		protected IDeviceActionRepository DeviceActionRepository { get; private set; }

		protected IApiDeviceActionRequestModelValidator DeviceActionModelValidator { get; private set; }

		protected IBOLDeviceActionMapper BolDeviceActionMapper { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceActionService(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
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

		public virtual async Task<List<ApiDeviceActionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeviceActionRepository.All(limit, offset);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceActionResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model)
		{
			CreateResponse<ApiDeviceActionResponseModel> response = new CreateResponse<ApiDeviceActionResponseModel>(await this.DeviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeviceActionMapper.MapModelToBO(default(int), model);
				var record = await this.DeviceActionRepository.Create(this.DalDeviceActionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeviceActionResponseModel>> Update(
			int id,
			ApiDeviceActionRequestModel model)
		{
			var validationResult = await this.DeviceActionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeviceActionMapper.MapModelToBO(id, model);
				await this.DeviceActionRepository.Update(this.DalDeviceActionMapper.MapBOToEF(bo));

				var record = await this.DeviceActionRepository.Get(id);

				return new UpdateResponse<ApiDeviceActionResponseModel>(this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeviceActionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.DeviceActionModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeviceActionRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiDeviceActionResponseModel>> ByDeviceId(int deviceId)
		{
			List<DeviceAction> records = await this.DeviceActionRepository.ByDeviceId(deviceId);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>830c97a20e719bd7f8c0a304b4396d7b</Hash>
</Codenesium>*/