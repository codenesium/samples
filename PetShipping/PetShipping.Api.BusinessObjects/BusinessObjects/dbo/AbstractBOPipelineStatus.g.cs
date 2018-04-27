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
	public abstract class AbstractBOPipelineStatus
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IPipelineStatusModelValidator pipelineStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStatus(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IPipelineStatusModelValidator pipelineStatusModelValidator)

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStatusRepository.GetById(id);
		}

		public virtual POCOPipelineStatus GetByIdDirect(int id)
		{
			return this.pipelineStatusRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStatus> GetWhereDirect(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5b3f60f7381e36a435d8a001dee54d48</Hash>
</Codenesium>*/