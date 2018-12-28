using MediatR;
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
		private IMediator mediator;

		protected IPipelineStepStepRequirementRepository PipelineStepStepRequirementRepository { get; private set; }

		protected IApiPipelineStepStepRequirementServerRequestModelValidator PipelineStepStepRequirementModelValidator { get; private set; }

		protected IBOLPipelineStepStepRequirementMapper BolPipelineStepStepRequirementMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStepRequirementService(
			ILogger logger,
			IMediator mediator,
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

			this.mediator = mediator;
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

				var businessObject = this.DalPipelineStepStepRequirementMapper.MapEFToBO(record);
				response.SetRecord(this.BolPipelineStepStepRequirementMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PipelineStepStepRequirementCreatedNotification(response.Record));
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

				var businessObject = this.DalPipelineStepStepRequirementMapper.MapEFToBO(record);
				var apiModel = this.BolPipelineStepStepRequirementMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PipelineStepStepRequirementUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new PipelineStepStepRequirementDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>670e19ad6bc7b74a02ef31930e008a9c</Hash>
</Codenesium>*/