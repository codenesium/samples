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
	public abstract class AbstractBOPipeline: AbstractBOManager
	{
		private IPipelineRepository pipelineRepository;
		private IApiPipelineModelValidator pipelineModelValidator;
		private ILogger logger;

		public AbstractBOPipeline(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineModelValidator pipelineModelValidator)
			: base()

		{
			this.pipelineRepository = pipelineRepository;
			this.pipelineModelValidator = pipelineModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPipeline> Get(int id)
		{
			return this.pipelineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipeline>> Create(
			ApiPipelineModel model)
		{
			CreateResponse<POCOPipeline> response = new CreateResponse<POCOPipeline>(await this.pipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipeline record = await this.pipelineRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.pipelineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3cad8b9c5f336b043cf02afc6f2877ce</Hash>
</Codenesium>*/