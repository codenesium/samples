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
	public abstract class AbstractBOPipelineStepStatus
	{
		private IPipelineStepStatusRepository pipelineStepStatusRepository;
		private IPipelineStepStatusModelValidator pipelineStepStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepStatus(
			ILogger logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IPipelineStepStatusModelValidator pipelineStepStatusModelValidator)

		{
			this.pipelineStepStatusRepository = pipelineStepStatusRepository;
			this.pipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStepStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStepStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStepStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStepStatusRepository.GetById(id);
		}

		public virtual POCOPipelineStepStatus GetByIdDirect(int id)
		{
			return this.pipelineStepStatusRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStatusRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStatusRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStepStatus> GetWhereDirect(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStatusRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>da7e6f3233879b46ae8004c5b481e9f9</Hash>
</Codenesium>*/