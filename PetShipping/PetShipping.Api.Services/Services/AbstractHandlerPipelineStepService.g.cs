using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractHandlerPipelineStepService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IHandlerPipelineStepRepository HandlerPipelineStepRepository { get; private set; }

		protected IApiHandlerPipelineStepServerRequestModelValidator HandlerPipelineStepModelValidator { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerPipelineStepService(
			ILogger logger,
			MediatR.IMediator mediator,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepServerRequestModelValidator handlerPipelineStepModelValidator,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base()
		{
			this.HandlerPipelineStepRepository = handlerPipelineStepRepository;
			this.HandlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiHandlerPipelineStepServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<HandlerPipelineStep> records = await this.HandlerPipelineStepRepository.All(limit, offset, query);

			return this.DalHandlerPipelineStepMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiHandlerPipelineStepServerResponseModel> Get(int id)
		{
			HandlerPipelineStep record = await this.HandlerPipelineStepRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalHandlerPipelineStepMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepServerResponseModel>> Create(
			ApiHandlerPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.CreateResponse(await this.HandlerPipelineStepModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				HandlerPipelineStep record = this.DalHandlerPipelineStepMapper.MapModelToEntity(default(int), model);
				record = await this.HandlerPipelineStepRepository.Create(record);

				response.SetRecord(this.DalHandlerPipelineStepMapper.MapEntityToModel(record));
				await this.mediator.Publish(new HandlerPipelineStepCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>> Update(
			int id,
			ApiHandlerPipelineStepServerRequestModel model)
		{
			var validationResult = await this.HandlerPipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				HandlerPipelineStep record = this.DalHandlerPipelineStepMapper.MapModelToEntity(id, model);
				await this.HandlerPipelineStepRepository.Update(record);

				record = await this.HandlerPipelineStepRepository.Get(id);

				ApiHandlerPipelineStepServerResponseModel apiModel = this.DalHandlerPipelineStepMapper.MapEntityToModel(record);
				await this.mediator.Publish(new HandlerPipelineStepUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.HandlerPipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.HandlerPipelineStepRepository.Delete(id);

				await this.mediator.Publish(new HandlerPipelineStepDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b72440e889481a45ba551fba44aa48ba</Hash>
</Codenesium>*/