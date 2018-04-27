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
	public abstract class AbstractBOHandlerPipelineStep
	{
		private IHandlerPipelineStepRepository handlerPipelineStepRepository;
		private IHandlerPipelineStepModelValidator handlerPipelineStepModelValidator;
		private ILogger logger;

		public AbstractBOHandlerPipelineStep(
			ILogger logger,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IHandlerPipelineStepModelValidator handlerPipelineStepModelValidator)

		{
			this.handlerPipelineStepRepository = handlerPipelineStepRepository;
			this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			HandlerPipelineStepModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.handlerPipelineStepRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			HandlerPipelineStepModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.handlerPipelineStepRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.handlerPipelineStepRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.handlerPipelineStepRepository.GetById(id);
		}

		public virtual POCOHandlerPipelineStep GetByIdDirect(int id)
		{
			return this.handlerPipelineStepRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerPipelineStepRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerPipelineStepRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOHandlerPipelineStep> GetWhereDirect(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerPipelineStepRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>0c5a78aa50ce8448e05932806302cbb8</Hash>
</Codenesium>*/