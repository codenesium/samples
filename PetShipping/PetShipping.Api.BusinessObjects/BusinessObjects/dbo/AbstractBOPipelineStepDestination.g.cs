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
		private IApiPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepDestination(
			ILogger logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationModelValidator pipelineStepDestinationModelValidator)

		{
			this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.pipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepDestinationRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipelineStepDestination Get(int id)
		{
			return this.pipelineStepDestinationRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepDestination>> Create(
			ApiPipelineStepDestinationModel model)
		{
			CreateResponse<POCOPipelineStepDestination> response = new CreateResponse<POCOPipelineStepDestination>(await this.pipelineStepDestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepDestination record = this.pipelineStepDestinationRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepDestinationModel model)
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
	}
}

/*<Codenesium>
    <Hash>d8dae5e8fa94ed3e0e39de473988fae4</Hash>
</Codenesium>*/