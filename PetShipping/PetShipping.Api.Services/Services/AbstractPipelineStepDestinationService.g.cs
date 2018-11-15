using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepDestinationService : AbstractService
	{
		protected IPipelineStepDestinationRepository PipelineStepDestinationRepository { get; private set; }

		protected IApiPipelineStepDestinationServerRequestModelValidator PipelineStepDestinationModelValidator { get; private set; }

		protected IBOLPipelineStepDestinationMapper BolPipelineStepDestinationMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepDestinationService(
			ILogger logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationServerRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base()
		{
			this.PipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.PipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.BolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepDestinationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepDestinationRepository.All(limit, offset);

			return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepDestinationServerResponseModel> Get(int id)
		{
			var record = await this.PipelineStepDestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationServerResponseModel>> Create(
			ApiPipelineStepDestinationServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepDestinationServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepDestinationServerResponseModel>.CreateResponse(await this.PipelineStepDestinationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStepDestinationMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepDestinationRepository.Create(this.DalPipelineStepDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepDestinationServerResponseModel>> Update(
			int id,
			ApiPipelineStepDestinationServerRequestModel model)
		{
			var validationResult = await this.PipelineStepDestinationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepDestinationMapper.MapModelToBO(id, model);
				await this.PipelineStepDestinationRepository.Update(this.DalPipelineStepDestinationMapper.MapBOToEF(bo));

				var record = await this.PipelineStepDestinationRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineStepDestinationServerResponseModel>.UpdateResponse(this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepDestinationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepDestinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepDestinationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5a3bce48b69b3fecd440241375f0402e</Hash>
</Codenesium>*/