using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class EventStatusService : AbstractService, IEventStatusService
	{
		private MediatR.IMediator mediator;

		protected IEventStatusRepository EventStatusRepository { get; private set; }

		protected IApiEventStatusServerRequestModelValidator EventStatusModelValidator { get; private set; }

		protected IDALEventStatusMapper DalEventStatusMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public EventStatusService(
			ILogger<IEventStatusService> logger,
			MediatR.IMediator mediator,
			IEventStatusRepository eventStatusRepository,
			IApiEventStatusServerRequestModelValidator eventStatusModelValidator,
			IDALEventStatusMapper dalEventStatusMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventStatusRepository = eventStatusRepository;
			this.EventStatusModelValidator = eventStatusModelValidator;
			this.DalEventStatusMapper = dalEventStatusMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<EventStatus> records = await this.EventStatusRepository.All(limit, offset, query);

			return this.DalEventStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEventStatusServerResponseModel> Get(int id)
		{
			EventStatus record = await this.EventStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEventStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEventStatusServerResponseModel>> Create(
			ApiEventStatusServerRequestModel model)
		{
			CreateResponse<ApiEventStatusServerResponseModel> response = ValidationResponseFactory<ApiEventStatusServerResponseModel>.CreateResponse(await this.EventStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				EventStatus record = this.DalEventStatusMapper.MapModelToEntity(default(int), model);
				record = await this.EventStatusRepository.Create(record);

				response.SetRecord(this.DalEventStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new EventStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStatusServerResponseModel>> Update(
			int id,
			ApiEventStatusServerRequestModel model)
		{
			var validationResult = await this.EventStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				EventStatus record = this.DalEventStatusMapper.MapModelToEntity(id, model);
				await this.EventStatusRepository.Update(record);

				record = await this.EventStatusRepository.Get(id);

				ApiEventStatusServerResponseModel apiModel = this.DalEventStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new EventStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEventStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiEventStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventStatusRepository.Delete(id);

				await this.mediator.Publish(new EventStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventStatusRepository.EventsByEventStatusId(eventStatusId, limit, offset);

			return this.DalEventMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a8759581220fd328cc65d1a9a2eb11f0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/