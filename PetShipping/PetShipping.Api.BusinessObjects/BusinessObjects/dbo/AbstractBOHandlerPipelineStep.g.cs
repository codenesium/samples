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
	public abstract class AbstractBOHandlerPipelineStep: AbstractBOManager
	{
		private IHandlerPipelineStepRepository handlerPipelineStepRepository;
		private IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator;
		private IBOLHandlerPipelineStepMapper handlerPipelineStepMapper;
		private ILogger logger;

		public AbstractBOHandlerPipelineStep(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper handlerPipelineStepMapper)
			: base()

		{
			this.handlerPipelineStepRepository = handlerPipelineStepRepository;
			this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.handlerPipelineStepMapper = handlerPipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.handlerPipelineStepRepository.All(skip, take, orderClause);

			return this.handlerPipelineStepMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiHandlerPipelineStepResponseModel> Get(int id)
		{
			var record = await handlerPipelineStepRepository.Get(id);

			return this.handlerPipelineStepMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
			ApiHandlerPipelineStepRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepResponseModel> response = new CreateResponse<ApiHandlerPipelineStepResponseModel>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.handlerPipelineStepMapper.MapModelToDTO(default (int), model);
				var record = await this.handlerPipelineStepRepository.Create(dto);

				response.SetRecord(this.handlerPipelineStepMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerPipelineStepRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.handlerPipelineStepMapper.MapModelToDTO(id, model);
				await this.handlerPipelineStepRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.handlerPipelineStepRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>144d87799a6c86636f06a98015673500</Hash>
</Codenesium>*/