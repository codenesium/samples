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
	public abstract class AbstractDeviceService : AbstractService
	{
		protected IDeviceRepository DeviceRepository { get; private set; }

		protected IApiDeviceRequestModelValidator DeviceModelValidator { get; private set; }

		protected IBOLDeviceMapper BolDeviceMapper { get; private set; }

		protected IDALDeviceMapper DalDeviceMapper { get; private set; }

		protected IBOLDeviceActionMapper BolDeviceActionMapper { get; private set; }

		protected IDALDeviceActionMapper DalDeviceActionMapper { get; private set; }

		private ILogger logger;

		public AbstractDeviceService(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
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

		public virtual async Task<List<ApiDeviceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeviceRepository.All(limit, offset);

			return this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiDeviceResponseModel>> Create(
			ApiDeviceRequestModel model)
		{
			CreateResponse<ApiDeviceResponseModel> response = new CreateResponse<ApiDeviceResponseModel>(await this.DeviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeviceMapper.MapModelToBO(default(int), model);
				var record = await this.DeviceRepository.Create(this.DalDeviceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeviceResponseModel>> Update(
			int id,
			ApiDeviceRequestModel model)
		{
			var validationResult = await this.DeviceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeviceMapper.MapModelToBO(id, model);
				await this.DeviceRepository.Update(this.DalDeviceMapper.MapBOToEF(bo));

				var record = await this.DeviceRepository.Get(id);

				return new UpdateResponse<ApiDeviceResponseModel>(this.BolDeviceMapper.MapBOToModel(this.DalDeviceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeviceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.DeviceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeviceRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiDeviceResponseModel> ByPublicId(Guid publicId)
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

		public async virtual Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0)
		{
			List<DeviceAction> records = await this.DeviceRepository.DeviceActions(deviceId, limit, offset);

			return this.BolDeviceActionMapper.MapBOToModel(this.DalDeviceActionMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4f2824900fe234d69c5b63df37d9a34d</Hash>
</Codenesium>*/