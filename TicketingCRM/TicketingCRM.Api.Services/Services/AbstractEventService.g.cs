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

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventService(
			ILogger logger,
			IMediator mediator,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventRepository = eventRepository;
			this.EventModelValidator = eventModelValidator;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Event> records = await this.EventRepository.All(limit, offset, query);

			return this.DalEventMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEventServerResponseModel> Get(int id)
		{
			Event record = await this.EventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEventMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model)
		{
			CreateResponse<ApiEventServerResponseModel> response = ValidationResponseFactory<ApiEventServerResponseModel>.CreateResponse(await this.EventModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Event record = this.DalEventMapper.MapModelToEntity(default(int), model);
				record = await this.EventRepository.Create(record);

				response.SetRecord(this.DalEventMapper.MapEntityToModel(record));
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
				Event record = this.DalEventMapper.MapModelToEntity(id, model);
				await this.EventRepository.Update(record);

				record = await this.EventRepository.Get(id);

				ApiEventServerResponseModel apiModel = this.DalEventMapper.MapEntityToModel(record);
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

			return this.DalEventMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e179a04096fe4d6093138648c7080908</Hash>
</Codenesium>*/