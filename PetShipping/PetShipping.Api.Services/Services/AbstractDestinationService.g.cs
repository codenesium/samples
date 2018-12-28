using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDestinationService : AbstractService
	{
		private IMediator mediator;

		protected IDestinationRepository DestinationRepository { get; private set; }

		protected IApiDestinationServerRequestModelValidator DestinationModelValidator { get; private set; }

		protected IBOLDestinationMapper BolDestinationMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		protected IBOLPipelineStepDestinationMapper BolPipelineStepDestinationMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractDestinationService(
			ILogger logger,
			IMediator mediator,
			IDestinationRepository destinationRepository,
			IApiDestinationServerRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base()
		{
			this.DestinationRepository = destinationRepository;
			this.DestinationModelValidator = destinationModelValidator;
			this.BolDestinationMapper = bolDestinationMapper;
			this.DalDestinationMapper = dalDestinationMapper;
			this.BolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDestinationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DestinationRepository.All(limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDestinationServerResponseModel> Get(int id)
		{
			var record = await this.DestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDestinationServerResponseModel>> Create(
			ApiDestinationServerRequestModel model)
		{
			CreateResponse<ApiDestinationServerResponseModel> response = ValidationResponseFactory<ApiDestinationServerResponseModel>.CreateResponse(await this.DestinationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(default(int), model);
				var record = await this.DestinationRepository.Create(this.DalDestinationMapper.MapBOToEF(bo));

				var businessObject = this.DalDestinationMapper.MapEFToBO(record);
				response.SetRecord(this.BolDestinationMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new DestinationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDestinationServerResponseModel>> Update(
			int id,
			ApiDestinationServerRequestModel model)
		{
			var validationResult = await this.DestinationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(id, model);
				await this.DestinationRepository.Update(this.DalDestinationMapper.MapBOToEF(bo));

				var record = await this.DestinationRepository.Get(id);

				var businessObject = this.DalDestinationMapper.MapEFToBO(record);
				var apiModel = this.BolDestinationMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new DestinationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDestinationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDestinationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DestinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.DestinationRepository.Delete(id);

				await this.mediator.Publish(new DestinationDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepDestination> records = await this.DestinationRepository.PipelineStepDestinationsByDestinationId(destinationId, limit, offset);

			return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c3b50c43f77a33a7c7a2ff8a421c2e18</Hash>
</Codenesium>*/