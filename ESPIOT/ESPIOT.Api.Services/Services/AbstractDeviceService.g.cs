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
	public abstract class AbstractDeviceService: AbstractService
	{
		private IDeviceRepository deviceRepository;
		private IApiDeviceRequestModelValidator deviceModelValidator;
		private IBOLDeviceMapper BOLDeviceMapper;
		private IDALDeviceMapper DALDeviceMapper;
		private ILogger logger;

		public AbstractDeviceService(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper boldeviceMapper,
			IDALDeviceMapper daldeviceMapper)
			: base()

		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
			this.BOLDeviceMapper = boldeviceMapper;
			this.DALDeviceMapper = daldeviceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.deviceRepository.All(skip, take, orderClause);

			return this.BOLDeviceMapper.MapBOToModel(this.DALDeviceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeviceResponseModel> Get(int id)
		{
			var record = await deviceRepository.Get(id);

			return this.BOLDeviceMapper.MapBOToModel(this.DALDeviceMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDeviceResponseModel>> Create(
			ApiDeviceRequestModel model)
		{
			CreateResponse<ApiDeviceResponseModel> response = new CreateResponse<ApiDeviceResponseModel>(await this.deviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLDeviceMapper.MapModelToBO(default (int), model);
				var record = await this.deviceRepository.Create(this.DALDeviceMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLDeviceMapper.MapBOToModel(this.DALDeviceMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDeviceRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLDeviceMapper.MapModelToBO(id, model);
				await this.deviceRepository.Update(this.DALDeviceMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.deviceRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiDeviceResponseModel> GetPublicId(Guid publicId)
		{
			Device record = await this.deviceRepository.GetPublicId(publicId);

			return this.BOLDeviceMapper.MapBOToModel(this.DALDeviceMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>147da7026f6f51b907eff17afb7b100e</Hash>
</Codenesium>*/