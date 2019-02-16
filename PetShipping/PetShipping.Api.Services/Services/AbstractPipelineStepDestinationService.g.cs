using MediatR;
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
		private IMediator mediator;

		protected IPipelineStepDestinationRepository PipelineStepDestinationRepository { get; private set; }

		protected IApiPipelineStepDestinationServerRequestModelValidator PipelineStepDestinationModelValidator { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepDestinationService(
			ILogger logger,
			IMediator mediator,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationServerRequestModelValidator pipelineStepDestinationModelValidator,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base()
		{
			this.PipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.PipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepDestinationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStepDestination> records = await this.PipelineStepDestinationRepository.All(limit, offset, query);

			return this.DalPipelineStepDestinationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepDestinationServerResponseModel> Get(int id)
		{
			PipelineStepDestination record = await this.PipelineStepDestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepDestinationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationServerResponseModel>> Create(
			ApiPipelineStepDestinationServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepDestinationServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepDestinationServerResponseModel>.CreateResponse(await this.PipelineStepDestinationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStepDestination record = this.DalPipelineStepDestinationMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepDestinationRepository.Create(record);

				response.SetRecord(this.DalPipelineStepDestinationMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStepDestinationCreatedNotification(response.Record));
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
				PipelineStepDestination record = this.DalPipelineStepDestinationMapper.MapModelToEntity(id, model);
				await this.PipelineStepDestinationRepository.Update(record);

				record = await this.PipelineStepDestinationRepository.Get(id);

				ApiPipelineStepDestinationServerResponseModel apiModel = this.DalPipelineStepDestinationMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStepDestinationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepDestinationServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new PipelineStepDestinationDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21896ce76bde134de7dc85ed807c1a15</Hash>
</Codenesium>*/