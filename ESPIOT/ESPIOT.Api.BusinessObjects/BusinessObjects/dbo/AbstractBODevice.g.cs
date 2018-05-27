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

namespace ESPIOTNS.Api.BusinessObjects
{
	public abstract class AbstractBODevice: AbstractBOManager
	{
		private IDeviceRepository deviceRepository;
		private IApiDeviceRequestModelValidator deviceModelValidator;
		private IBOLDeviceMapper deviceMapper;
		private ILogger logger;

		public AbstractBODevice(
			ILogger logger,
			IDeviceRepository deviceRepository,
			IApiDeviceRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper deviceMapper)
			: base()

		{
			this.deviceRepository = deviceRepository;
			this.deviceModelValidator = deviceModelValidator;
			this.deviceMapper = deviceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.deviceRepository.All(skip, take, orderClause);

			return this.deviceMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiDeviceResponseModel> Get(int id)
		{
			var record = await deviceRepository.Get(id);

			return this.deviceMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiDeviceResponseModel>> Create(
			ApiDeviceRequestModel model)
		{
			CreateResponse<ApiDeviceResponseModel> response = new CreateResponse<ApiDeviceResponseModel>(await this.deviceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.deviceMapper.MapModelToDTO(default (int), model);
				var record = await this.deviceRepository.Create(dto);

				response.SetRecord(this.deviceMapper.MapDTOToModel(record));
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
				var dto = this.deviceMapper.MapModelToDTO(id, model);
				await this.deviceRepository.Update(id, dto);
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

		public async Task<ApiDeviceResponseModel> PublicId(Guid publicId)
		{
			DTODevice record = await this.deviceRepository.PublicId(publicId);

			return this.deviceMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>c5eb474a450c4d64ed7a1738855b87bc</Hash>
</Codenesium>*/