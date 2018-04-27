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
	public abstract class AbstractBOPipelineStepStepRequirement
	{
		private IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;
		private IPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepStepRequirement(
			ILogger logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator)

		{
			this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.pipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStepStepRequirementModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStepStepRequirementRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStepStepRequirementModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStepStepRequirementRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStepStepRequirementRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.pipelineStepStepRequirementRepository.GetById(id);
		}

		public virtual POCOPipelineStepStepRequirement GetByIdDirect(int id)
		{
			return this.pipelineStepStepRequirementRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStepRequirementRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStepRequirementRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPipelineStepStepRequirement> GetWhereDirect(Expression<Func<EFPipelineStepStepRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStepRequirementRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>68a656e5cc232c418aa35b1b4bfc7270</Hash>
</Codenesium>*/