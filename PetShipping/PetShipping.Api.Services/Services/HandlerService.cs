using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class HandlerService : AbstractService, IHandlerService
	{
		private MediatR.IMediator mediator;

		protected IHandlerRepository HandlerRepository { get; private set; }

		protected IApiHandlerServerRequestModelValidator HandlerModelValidator { get; private set; }

		protected IDALHandlerMapper DalHandlerMapper { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		private ILogger logger;

		public HandlerService(
			ILogger<IHandlerService> logger,
			MediatR.IMediator mediator,
			IHandlerRepository handlerRepository,
			IApiHandlerServerRequestModelValidator handlerModelValidator,
			IDALHandlerMapper dalHandlerMapper,
			IDALAirTransportMapper dalAirTransportMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base()
		{
			this.HandlerRepository = handlerRepository;
			this.HandlerModelValidator = handlerModelValidator;
			this.DalHandlerMapper = dalHandlerMapper;
			this.DalAirTransportMapper = dalAirTransportMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiHandlerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Handler> records = await this.HandlerRepository.All(limit, offset, query);

			return this.DalHandlerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiHandlerServerResponseModel> Get(int id)
		{
			Handler record = await this.HandlerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalHandlerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerServerResponseModel>> Create(
			ApiHandlerServerRequestModel model)
		{
			CreateResponse<ApiHandlerServerResponseModel> response = ValidationResponseFactory<ApiHandlerServerResponseModel>.CreateResponse(await this.HandlerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Handler record = this.DalHandlerMapper.MapModelToEntity(default(int), model);
				record = await this.HandlerRepository.Create(record);

				response.SetRecord(this.DalHandlerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new HandlerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerServerResponseModel>> Update(
			int id,
			ApiHandlerServerRequestModel model)
		{
			var validationResult = await this.HandlerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Handler record = this.DalHandlerMapper.MapModelToEntity(id, model);
				await this.HandlerRepository.Update(record);

				record = await this.HandlerRepository.Get(id);

				ApiHandlerServerResponseModel apiModel = this.DalHandlerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new HandlerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiHandlerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiHandlerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.HandlerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.HandlerRepository.Delete(id);

				await this.mediator.Publish(new HandlerDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiAirTransportServerResponseModel>> AirTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<AirTransport> records = await this.HandlerRepository.AirTransportsByHandlerId(handlerId, limit, offset);

			return this.DalAirTransportMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiHandlerPipelineStepServerResponseModel>> HandlerPipelineStepsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.HandlerRepository.HandlerPipelineStepsByHandlerId(handlerId, limit, offset);

			return this.DalHandlerPipelineStepMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiOtherTransportServerResponseModel>> OtherTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.HandlerRepository.OtherTransportsByHandlerId(handlerId, limit, offset);

			return this.DalOtherTransportMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7232c4a6ad112100cb6cb3cc59905289</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/