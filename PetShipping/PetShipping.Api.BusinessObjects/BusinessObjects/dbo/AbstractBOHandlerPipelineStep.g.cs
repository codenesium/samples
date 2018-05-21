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
		private IApiHandlerPipelineStepModelValidator handlerPipelineStepModelValidator;
		private ILogger logger;

		public AbstractBOHandlerPipelineStep(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepModelValidator handlerPipelineStepModelValidator)
			: base()

		{
			this.handlerPipelineStepRepository = handlerPipelineStepRepository;
			this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerPipelineStepRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOHandlerPipelineStep> Get(int id)
		{
			return this.handlerPipelineStepRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOHandlerPipelineStep>> Create(
			ApiHandlerPipelineStepModel model)
		{
			CreateResponse<POCOHandlerPipelineStep> response = new CreateResponse<POCOHandlerPipelineStep>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOHandlerPipelineStep record = await this.handlerPipelineStepRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerPipelineStepModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.handlerPipelineStepRepository.Update(id, model);
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
    <Hash>23c16bcb3ae7da79313ada6d59e9aa34</Hash>
</Codenesium>*/