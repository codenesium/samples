using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepStepRequirementService : AbstractService
	{
		protected IPipelineStepStepRequirementRepository PipelineStepStepRequirementRepository { get; private set; }

		protected IApiPipelineStepStepRequirementServerRequestModelValidator PipelineStepStepRequirementModelValidator { get; private set; }

		protected IBOLPipelineStepStepRequirementMapper BolPipelineStepStepRequirementMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStepRequirementService(
			ILogger logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementServerRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base()
		{
			this.PipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.PipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.BolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepStepRequirementRepository.All(limit, offset);

			return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepStepRequirementServerResponseModel> Get(int id)
		{
			var record = await this.PipelineStepStepRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>> Create(
			ApiPipelineStepStepRequirementServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.CreateResponse(await this.PipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStepStepRequirementMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepStepRequirementRepository.Create(this.DalPipelineStepStepRequirementMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStepRequirementServerResponseModel>> Update(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel model)
		{
			var validationResult = await this.PipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepStepRequirementMapper.MapModelToBO(id, model);
				await this.PipelineStepStepRequirementRepository.Update(this.DalPipelineStepStepRequirementMapper.MapBOToEF(bo));

				var record = await this.PipelineStepStepRequirementRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.UpdateResponse(this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepStepRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepStepRequirementRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>139de0c30fffb009aabaed8f78530604</Hash>
</Codenesium>*/