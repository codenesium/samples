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
	public abstract class AbstractBOPipelineStepStatus: AbstractBOManager
	{
		private IPipelineStepStatusRepository pipelineStepStatusRepository;
		private IApiPipelineStepStatusModelValidator pipelineStepStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepStatus(
			ILogger logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusModelValidator pipelineStepStatusModelValidator)
			: base()

		{
			this.pipelineStepStatusRepository = pipelineStepStatusRepository;
			this.pipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStatusRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPipelineStepStatus> Get(int id)
		{
			return this.pipelineStepStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepStatus>> Create(
			ApiPipelineStepStatusModel model)
		{
			CreateResponse<POCOPipelineStepStatus> response = new CreateResponse<POCOPipelineStepStatus>(await this.pipelineStepStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepStatus record = await this.pipelineStepStatusRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.pipelineStepStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d0b8fe11fbec36e07e6750708870854e</Hash>
</Codenesium>*/