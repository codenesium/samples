using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractEventTeacherService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IEventTeacherRepository EventTeacherRepository { get; private set; }

		protected IApiEventTeacherServerRequestModelValidator EventTeacherModelValidator { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		private ILogger logger;

		public AbstractEventTeacherService(
			ILogger logger,
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

		public virtual async Task<ApiEventTeacherServerResponseModel> Get(int eventId)
		{
			EventTeacher record = await this.EventTeacherRepository.Get(eventId);

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
			int eventId,
			ApiEventTeacherServerRequestModel model)
		{
			var validationResult = await this.EventTeacherModelValidator.ValidateUpdateAsync(eventId, model);

			if (validationResult.IsValid)
			{
				EventTeacher record = this.DalEventTeacherMapper.MapModelToEntity(eventId, model);
				await this.EventTeacherRepository.Update(record);

				record = await this.EventTeacherRepository.Get(eventId);

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
			int eventId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventTeacherModelValidator.ValidateDeleteAsync(eventId));

			if (response.Success)
			{
				await this.EventTeacherRepository.Delete(eventId);

				await this.mediator.Publish(new EventTeacherDeletedNotification(eventId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2102486d23ac8eb1c2f708eb42ff1ca7</Hash>
</Codenesium>*/