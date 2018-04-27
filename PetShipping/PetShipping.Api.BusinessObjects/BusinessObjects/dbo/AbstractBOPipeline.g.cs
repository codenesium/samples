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
	public abstract class AbstractBOPipeline
	{
		private IPipelineRepository pipelineRepository;
		private IPipelineModelValidator pipelineModelValidator;
		private ILogger logger;

		public AbstractBOPipeline(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IPipelineModelValidator pipelineModelValidator)

		{
			this.pipelineRepository = pipelineRepository;
			this.pipelineModelValidator = pipelineModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineRepository.GetById(id);
		}

		public virtual POCOPipeline GetByIdDirect(int id)
		{
			return this.pipelineRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipeline> GetWhereDirect(Expression<Func<EFPipeline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8c6476ed0ee2ca29539bf89fdd5b3f2c</Hash>
</Codenesium>*/