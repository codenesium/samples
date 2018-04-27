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
	public abstract class AbstractBOPipelineStep
	{
		private IPipelineStepRepository pipelineStepRepository;
		private IPipelineStepModelValidator pipelineStepModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStep(
			ILogger logger,
			IPipelineStepRepository pipelineStepRepository,
			IPipelineStepModelValidator pipelineStepModelValidator)

		{
			this.pipelineStepRepository = pipelineStepRepository;
			this.pipelineStepModelValidator = pipelineStepModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStepModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStepRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStepRepository.GetById(id);
		}

		public virtual POCOPipelineStep GetByIdDirect(int id)
		{
			return this.pipelineStepRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStep> GetWhereDirect(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>95de0b119710717ca272e89ecb723188</Hash>
</Codenesium>*/