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
	public abstract class AbstractBOPipelineStepStepRequirement: AbstractBOManager
	{
		private IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;
		private IApiPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStepStepRequirement(
			ILogger logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementModelValidator pipelineStepStepRequirementModelValidator)
			: base()

		{
			this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.pipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStepRequirementRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPipelineStepStepRequirement> Get(int id)
		{
			return this.pipelineStepStepRequirementRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepStepRequirement>> Create(
			ApiPipelineStepStepRequirementModel model)
		{
			CreateResponse<POCOPipelineStepStepRequirement> response = new CreateResponse<POCOPipelineStepStepRequirement>(await this.pipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepStepRequirement record = await this.pipelineStepStepRequirementRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepStepRequirementModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.pipelineStepStepRequirementRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepStepRequirementRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1de5cbf35f70fd8160514dbf6a64bcd0</Hash>
</Codenesium>*/