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

		public virtual List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStepStepRequirementRepository.All(skip, take, orderClause);
		}

		public virtual POCOPipelineStepStepRequirement Get(int id)
		{
			return this.pipelineStepStepRequirementRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStepStepRequirement>> Create(
			PipelineStepStepRequirementModel model)
		{
			CreateResponse<POCOPipelineStepStepRequirement> response = new CreateResponse<POCOPipelineStepStepRequirement>(await this.pipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStepStepRequirement record = this.pipelineStepStepRequirementRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>4a24b64f810d015d94939f453ad5103e</Hash>
</Codenesium>*/