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
		private IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator;
		private IBOLPipelineStepStepRequirementMapper pipelineStepStepRequirementMapper;
		private ILogger logger;

		public AbstractBOPipelineStepStepRequirement(
			ILogger logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper pipelineStepStepRequirementMapper)
			: base()

		{
			this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.pipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.pipelineStepStepRequirementMapper = pipelineStepStepRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepStepRequirementRepository.All(skip, take, orderClause);

			return this.pipelineStepStepRequirementMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> Get(int id)
		{
			var record = await pipelineStepStepRequirementRepository.Get(id);

			return this.pipelineStepStepRequirementMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> Create(
			ApiPipelineStepStepRequirementRequestModel model)
		{
			CreateResponse<ApiPipelineStepStepRequirementResponseModel> response = new CreateResponse<ApiPipelineStepStepRequirementResponseModel>(await this.pipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStepStepRequirementMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStepStepRequirementRepository.Create(dto);

				response.SetRecord(this.pipelineStepStepRequirementMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepStepRequirementRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStepStepRequirementMapper.MapModelToDTO(id, model);
				await this.pipelineStepStepRequirementRepository.Update(id, dto);
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
    <Hash>6f8f025836700cb2de4d039825af0ad6</Hash>
</Codenesium>*/