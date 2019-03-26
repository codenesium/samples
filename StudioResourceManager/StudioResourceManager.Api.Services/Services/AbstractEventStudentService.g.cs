using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractEventStudentService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IEventStudentRepository EventStudentRepository { get; private set; }

		protected IApiEventStudentServerRequestModelValidator EventStudentModelValidator { get; private set; }

		protected IDALEventStudentMapper DalEventStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStudentService(
			ILogger logger,
			MediatR.IMediator mediator,
			IEventStudentRepository eventStudentRepository,
			IApiEventStudentServerRequestModelValidator eventStudentModelValidator,
			IDALEventStudentMapper dalEventStudentMapper)
			: base()
		{
			this.EventStudentRepository = eventStudentRepository;
			this.EventStudentModelValidator = eventStudentModelValidator;
			this.DalEventStudentMapper = dalEventStudentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventStudentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<EventStudent> records = await this.EventStudentRepository.All(limit, offset, query);

			return this.DalEventStudentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEventStudentServerResponseModel> Get(int id)
		{
			EventStudent record = await this.EventStudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEventStudentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEventStudentServerResponseModel>> Create(
			ApiEventStudentServerRequestModel model)
		{
			CreateResponse<ApiEventStudentServerResponseModel> response = ValidationResponseFactory<ApiEventStudentServerResponseModel>.CreateResponse(await this.EventStudentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				EventStudent record = this.DalEventStudentMapper.MapModelToEntity(default(int), model);
				record = await this.EventStudentRepository.Create(record);

				response.SetRecord(this.DalEventStudentMapper.MapEntityToModel(record));
				await this.mediator.Publish(new EventStudentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStudentServerResponseModel>> Update(
			int id,
			ApiEventStudentServerRequestModel model)
		{
			var validationResult = await this.EventStudentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				EventStudent record = this.DalEventStudentMapper.MapModelToEntity(id, model);
				await this.EventStudentRepository.Update(record);

				record = await this.EventStudentRepository.Get(id);

				ApiEventStudentServerResponseModel apiModel = this.DalEventStudentMapper.MapEntityToModel(record);
				await this.mediator.Publish(new EventStudentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEventStudentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiEventStudentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventStudentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventStudentRepository.Delete(id);

				await this.mediator.Publish(new EventStudentDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiEventStudentServerResponseModel>> ByEventId(int eventId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventStudent> records = await this.EventStudentRepository.ByEventId(eventId, limit, offset);

			return this.DalEventStudentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventStudentServerResponseModel>> ByStudentId(int studentId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventStudent> records = await this.EventStudentRepository.ByStudentId(studentId, limit, offset);

			return this.DalEventStudentMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>22244696a1a40ca0ee1981ec710162df</Hash>
</Codenesium>*/