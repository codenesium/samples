using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOHandler: AbstractBOManager
	{
		private IHandlerRepository handlerRepository;
		private IApiHandlerRequestModelValidator handlerModelValidator;
		private IBOLHandlerMapper handlerMapper;
		private ILogger logger;

		public AbstractBOHandler(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper handlerMapper)
			: base()

		{
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.handlerMapper = handlerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.handlerRepository.All(skip, take, orderClause);

			return this.handlerMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiHandlerResponseModel> Get(int id)
		{
			var record = await handlerRepository.Get(id);

			return this.handlerMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.handlerMapper.MapModelToDTO(default (int), model);
				var record = await this.handlerRepository.Create(dto);

				response.SetRecord(this.handlerMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.handlerMapper.MapModelToDTO(id, model);
				await this.handlerRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.handlerRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c5758ec0d320ccf545ebcadec64659fc</Hash>
</Codenesium>*/