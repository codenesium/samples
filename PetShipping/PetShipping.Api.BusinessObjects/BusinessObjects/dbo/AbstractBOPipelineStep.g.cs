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

		public virtual POCOPipelineStep Get(int id)
		{
			return this.pipelineStepRepository.Get(id);
		}

		public virtual List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4ec08026ff87e33c96665006eb46e9b8</Hash>
</Codenesium>*/