using MediatR;
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
		private IMediator mediator;

		protected IHandlerPipelineStepRepository HandlerPipelineStepRepository { get; private set; }

		protected IApiHandlerPipelineStepServerRequestModelValidator HandlerPipelineStepModelValidator { get; private set; }

		protected IBOLHandlerPipelineStepMapper BolHandlerPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerPipelineStepService(
			ILogger logger,
			IMediator mediator,
			IHandlerPipelineStepRepository handlerPipelineStepRepository,
			IApiHandlerPipelineStepServerRequestModelValidator handlerPipelineStepModelValidator,
			IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
			: base()
		{
			this.HandlerPipelineStepRepository = handlerPipelineStepRepository;
			this.HandlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
			this.BolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiHandlerPipelineStepServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.HandlerPipelineStepRepository.All(limit, offset);

			return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerPipelineStepServerResponseModel> Get(int id)
		{
			var record = await this.HandlerPipelineStepRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolHandlerPipelineStepMapper.MapBOToModel(this.DalHandlerPipelineStepMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerPipelineStepServerResponseModel>> Create(
			ApiHandlerPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = ValidationResponseFactory<ApiHandlerPipelineStepServerResponseModel>.CreateResponse(await this.HandlerPipelineStepModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(default(int), model);
				var record = await this.HandlerPipelineStepRepository.Create(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				var businessObject = this.DalHandlerPipelineStepMapper.MapEFToBO(record);
				response.SetRecord(this.BolHandlerPipelineStepMapper.MapBOToModel(businessObject));
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
				var bo = this.BolHandlerPipelineStepMapper.MapModelToBO(id, model);
				await this.HandlerPipelineStepRepository.Update(this.DalHandlerPipelineStepMapper.MapBOToEF(bo));

				var record = await this.HandlerPipelineStepRepository.Get(id);

				var businessObject = this.DalHandlerPipelineStepMapper.MapEFToBO(record);
				var apiModel = this.BolHandlerPipelineStepMapper.MapBOToModel(businessObject);
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
    <Hash>1b42690c6be25206def010772b1437dd</Hash>
</Codenesium>*/