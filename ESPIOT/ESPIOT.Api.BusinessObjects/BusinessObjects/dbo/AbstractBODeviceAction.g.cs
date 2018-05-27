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
	public abstract class AbstractBODeviceAction: AbstractBOManager
	{
		private IDeviceActionRepository deviceActionRepository;
		private IApiDeviceActionRequestModelValidator deviceActionModelValidator;
		private IBOLDeviceActionMapper deviceActionMapper;
		private ILogger logger;

		public AbstractBODeviceAction(
			ILogger logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper deviceActionMapper)
			: base()

		{
			this.deviceActionRepository = deviceActionRepository;
			this.deviceActionModelValidator = deviceActionModelValidator;
			this.deviceActionMapper = deviceActionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeviceActionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.deviceActionRepository.All(skip, take, orderClause);

			return this.deviceActionMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiDeviceActionResponseModel> Get(int id)
		{
			var record = await deviceActionRepository.Get(id);

			return this.deviceActionMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiDeviceActionResponseModel>> Create(
			ApiDeviceActionRequestModel model)
		{
			CreateResponse<ApiDeviceActionResponseModel> response = new CreateResponse<ApiDeviceActionResponseModel>(await this.deviceActionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.deviceActionMapper.MapModelToDTO(default (int), model);
				var record = await this.deviceActionRepository.Create(dto);

				response.SetRecord(this.deviceActionMapper.MapDTOToModel(record));
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
				var dto = this.deviceActionMapper.MapModelToDTO(id, model);
				await this.deviceActionRepository.Update(id, dto);
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
	}
}

/*<Codenesium>
    <Hash>aa0eab5f9f0e5e83d54879d0fa011e4d</Hash>
</Codenesium>*/