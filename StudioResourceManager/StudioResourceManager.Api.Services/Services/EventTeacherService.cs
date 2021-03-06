using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class EventTeacherService : AbstractService, IEventTeacherService
	{
		private MediatR.IMediator mediator;

		protected IEventTeacherRepository EventTeacherRepository { get; private set; }

		protected IApiEventTeacherServerRequestModelValidator EventTeacherModelValidator { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		private ILogger logger;

		public EventTeacherService(
			ILogger<IEventTeacherService> logger,
			MediatR.IMediator mediator,
			IEventTeacherRepository eventTeacherRepository,
			IApiEventTeacherServerRequestModelValidator eventTeacherModelValidator,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base()
		{
			this.EventTeacherRepository = eventTeacherRepository;
			this.EventTeacherModelValidator = eventTeacherModelValidator;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventTeacherServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<EventTeacher> records = await this.EventTeacherRepository.All(limit, offset, query);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEventTeacherServerResponseModel> Get(int id)
		{
			EventTeacher record = await this.EventTeacherRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEventTeacherMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEventTeacherServerResponseModel>> Create(
			ApiEventTeacherServerRequestModel model)
		{
			CreateResponse<ApiEventTeacherServerResponseModel> response = ValidationResponseFactory<ApiEventTeacherServerResponseModel>.CreateResponse(await this.EventTeacherModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				EventTeacher record = this.DalEventTeacherMapper.MapModelToEntity(default(int), model);
				record = await this.EventTeacherRepository.Create(record);

				response.SetRecord(this.DalEventTeacherMapper.MapEntityToModel(record));
				await this.mediator.Publish(new EventTeacherCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventTeacherServerResponseModel>> Update(
			int id,
			ApiEventTeacherServerRequestModel model)
		{
			var validationResult = await this.EventTeacherModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				EventTeacher record = this.DalEventTeacherMapper.MapModelToEntity(id, model);
				await this.EventTeacherRepository.Update(record);

				record = await this.EventTeacherRepository.Get(id);

				ApiEventTeacherServerResponseModel apiModel = this.DalEventTeacherMapper.MapEntityToModel(record);
				await this.mediator.Publish(new EventTeacherUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEventTeacherServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiEventTeacherServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventTeacherModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventTeacherRepository.Delete(id);

				await this.mediator.Publish(new EventTeacherDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiEventTeacherServerResponseModel>> ByTeacherId(int teacherId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventTeacher> records = await this.EventTeacherRepository.ByTeacherId(teacherId, limit, offset);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventTeacherServerResponseModel>> ByEventId(int eventId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventTeacher> records = await this.EventTeacherRepository.ByEventId(eventId, limit, offset);

			return this.DalEventTeacherMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5b90d6a9457267be7c877146ce3ea6de</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/