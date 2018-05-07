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
	public abstract class AbstractBOPipelineStepDestination
	{
		private IPipelineStepDestinationRepository pipelineStepDestinationRepository;
		private IPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepDestination(
			ILogger logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator)

		{
			this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.pipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStepDestinationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStepDestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStepDestinationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepDestinationModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepDestinationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepDestinationRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepDestinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepDestinationRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOPipelineStepDestination Get(int id)
		{
			return this.pipelineStepDestinationRepository.Get(id);
		}

		public virtual List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepDestinationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>dc2176f87ead35d0feeb19b7e0c984c5</Hash>
</Codenesium>*/