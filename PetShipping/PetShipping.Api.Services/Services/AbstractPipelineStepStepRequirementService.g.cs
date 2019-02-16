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

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStepRequirementService(
			ILogger logger,
			IMediator mediator,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementServerRequestModelValidator pipelineStepStepRequirementModelValidator,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base()
		{
			this.PipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.PipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStepStepRequirement> records = await this.PipelineStepStepRequirementRepository.All(limit, offset, query);

			return this.DalPipelineStepStepRequirementMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepStepRequirementServerResponseModel> Get(int id)
		{
			PipelineStepStepRequirement record = await this.PipelineStepStepRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepStepRequirementMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementServerResponseModel>> Create(
			ApiPipelineStepStepRequirementServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStepRequirementServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStepRequirementServerResponseModel>.CreateResponse(await this.PipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStepStepRequirement record = this.DalPipelineStepStepRequirementMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepStepRequirementRepository.Create(record);

				response.SetRecord(this.DalPipelineStepStepRequirementMapper.MapEntityToModel(record));
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
				PipelineStepStepRequirement record = this.DalPipelineStepStepRequirementMapper.MapModelToEntity(id, model);
				await this.PipelineStepStepRequirementRepository.Update(record);

				record = await this.PipelineStepStepRequirementRepository.Get(id);

				ApiPipelineStepStepRequirementServerResponseModel apiModel = this.DalPipelineStepStepRequirementMapper.MapEntityToModel(record);
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
    <Hash>39e77fa1c9023c7781d009fc3b7aecf7</Hash>
</Codenesium>*/