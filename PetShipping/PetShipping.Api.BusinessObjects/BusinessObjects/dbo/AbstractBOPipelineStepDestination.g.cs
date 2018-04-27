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

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStepDestinationRepository.GetById(id);
		}

		public virtual POCOPipelineStepDestination GetByIdDirect(int id)
		{
			return this.pipelineStepDestinationRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepDestinationRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepDestinationRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStepDestination> GetWhereDirect(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepDestinationRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3db23557bfe068572ed0a1bed3e737c6</Hash>
</Codenesium>*/