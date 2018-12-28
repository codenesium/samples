using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractEventService : AbstractService
	{
		private IMediator mediator;

		protected IEventRepository EventRepository { get; private set; }

		protected IApiEventServerRequestModelValidator EventModelValidator { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventService(
			ILogger logger,
			IMediator mediator,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventRepository = eventRepository;
			this.EventModelValidator = eventModelValidator;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventRepository.All(limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventServerResponseModel> Get(int id)
		{
			var record = await this.EventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model)
		{
			CreateResponse<ApiEventServerResponseModel> response = ValidationResponseFactory<ApiEventServerResponseModel>.CreateResponse(await this.EventModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEventMapper.MapModelToBO(default(int), model);
				var record = await this.EventRepository.Create(this.DalEventMapper.MapBOToEF(bo));

				var businessObject = this.DalEventMapper.MapEFToBO(record);
				response.SetRecord(this.BolEventMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new EventCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventServerResponseModel>> Update(
			int id,
			ApiEventServerRequestModel model)
		{
			var validationResult = await this.EventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventMapper.MapModelToBO(id, model);
				await this.EventRepository.Update(this.DalEventMapper.MapBOToEF(bo));

				var record = await this.EventRepository.Get(id);

				var businessObject = this.DalEventMapper.MapEFToBO(record);
				var apiModel = this.BolEventMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new EventUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEventServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiEventServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventRepository.Delete(id);

				await this.mediator.Publish(new EventDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiEventServerResponseModel>> ByCityId(int cityId, int limit = 0, int offset = int.MaxValue)
		{
			List<Event> records = await this.EventRepository.ByCityId(cityId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2bd8064eab6aa3088a6b66f7ba06f3f9</Hash>
</Codenesium>*/