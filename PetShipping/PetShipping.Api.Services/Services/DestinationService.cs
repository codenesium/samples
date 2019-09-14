using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class DestinationService : AbstractService, IDestinationService
	{
		private MediatR.IMediator mediator;

		protected IDestinationRepository DestinationRepository { get; private set; }

		protected IApiDestinationServerRequestModelValidator DestinationModelValidator { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		private ILogger logger;

		public DestinationService(
			ILogger<IDestinationService> logger,
			MediatR.IMediator mediator,
			IDestinationRepository destinationRepository,
			IApiDestinationServerRequestModelValidator destinationModelValidator,
			IDALDestinationMapper dalDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base()
		{
			this.DestinationRepository = destinationRepository;
			this.DestinationModelValidator = destinationModelValidator;
			this.DalDestinationMapper = dalDestinationMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDestinationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Destination> records = await this.DestinationRepository.All(limit, offset, query);

			return this.DalDestinationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDestinationServerResponseModel> Get(int id)
		{
			Destination record = await this.DestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDestinationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDestinationServerResponseModel>> Create(
			ApiDestinationServerRequestModel model)
		{
			CreateResponse<ApiDestinationServerResponseModel> response = ValidationResponseFactory<ApiDestinationServerResponseModel>.CreateResponse(await this.DestinationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Destination record = this.DalDestinationMapper.MapModelToEntity(default(int), model);
				record = await this.DestinationRepository.Create(record);

				response.SetRecord(this.DalDestinationMapper.MapEntityToModel(record));
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
				Destination record = this.DalDestinationMapper.MapModelToEntity(id, model);
				await this.DestinationRepository.Update(record);

				record = await this.DestinationRepository.Get(id);

				ApiDestinationServerResponseModel apiModel = this.DalDestinationMapper.MapEntityToModel(record);
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

			return this.DalPipelineStepDestinationMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>60bbaab4478dfbf56d0ed4e2e4f66a7f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/