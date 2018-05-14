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

		public virtual List<POCOPipeline> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipeline Get(int id)
		{
			return this.pipelineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipeline>> Create(
			PipelineModel model)
		{
			CreateResponse<POCOPipeline> response = new CreateResponse<POCOPipeline>(await this.pipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipeline record = this.pipelineRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>c6a053ebb9404f5d13a6506f8b47da95</Hash>
</Codenesium>*/