using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractEventStatuService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IEventStatuRepository EventStatuRepository { get; private set; }

		protected IApiEventStatuServerRequestModelValidator EventStatuModelValidator { get; private set; }

		protected IDALEventStatuMapper DalEventStatuMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStatuService(
			ILogger logger,
			MediatR.IMediator mediator,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IDALEventStatuMapper dalEventStatuMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventStatuRepository = eventStatuRepository;
			this.EventStatuModelValidator = eventStatuModelValidator;
			this.DalEventStatuMapper = dalEventStatuMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<EventStatu> records = await this.EventStatuRepository.All(limit, offset, query);

			return this.DalEventStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiEventStatuServerResponseModel> Get(int id)
		{
			EventStatu record = await this.EventStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalEventStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiEventStatuServerResponseModel>> Create(
			ApiEventStatuServerRequestModel model)
		{
			CreateResponse<ApiEventStatuServerResponseModel> response = ValidationResponseFactory<ApiEventStatuServerResponseModel>.CreateResponse(await this.EventStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				EventStatu record = this.DalEventStatuMapper.MapModelToEntity(default(int), model);
				record = await this.EventStatuRepository.Create(record);

				response.SetRecord(this.DalEventStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new EventStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStatuServerResponseModel>> Update(
			int id,
			ApiEventStatuServerRequestModel model)
		{
			var validationResult = await this.EventStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				EventStatu record = this.DalEventStatuMapper.MapModelToEntity(id, model);
				await this.EventStatuRepository.Update(record);

				record = await this.EventStatuRepository.Get(id);

				ApiEventStatuServerResponseModel apiModel = this.DalEventStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new EventStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiEventStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiEventStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EventStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.EventStatuRepository.Delete(id);

				await this.mediator.Publish(new EventStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.EventStatuRepository.EventsByEventStatusId(eventStatusId, limit, offset);

			return this.DalEventMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>18c5720f6e44a302759859e6dbca8797</Hash>
</Codenesium>*/