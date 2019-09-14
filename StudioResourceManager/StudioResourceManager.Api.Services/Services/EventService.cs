using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class EventService : AbstractService, IEventService
	{
		private MediatR.IMediator mediator;

		protected IEventRepository EventRepository { get; private set; }

		protected IApiEventServerRequestModelValidator EventModelValidator { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		protected IDALEventStudentMapper DalEventStudentMapper { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		private ILogger logger;

		public EventService(
			ILogger<IEventService> logger,
			MediatR.IMediator mediator,
			IEventRepository eventRepository,
			IApiEventServerRequestModelValidator eventModelValidator,
			IDALEventMapper dalEventMapper,
			IDALEventStudentMapper dalEventStudentMapper,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base()
		{
			this.EventRepository = eventRepository;
			this.EventModelValidator = eventModelValidator;
			this.DalEventMapper = dalEventMapper;
			this.DalEventStudentMapper = dalEventStudentMapper;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
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

		public async virtual Task<List<ApiEventServerResponseModel>> ByEventStatusId(int eventStatusId, int limit = 0, int offset = int.MaxValue)
		{
			List<Event> records = await this.EventRepository.ByEventStatusId(eventStatusId, limit, offset);

			return this.DalEventMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventStudentServerResponseModel>> EventStudentsByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventStudent> records = await this.EventRepository.EventStudentsByEventId(eventId, limit, offset);

			return this.DalEventStudentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventTeacher> records = await this.EventRepository.EventTeachersByEventId(eventId, limit, offset);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>b048852dbc04b7bad449113fe538e234</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/