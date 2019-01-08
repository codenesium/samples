using MediatR;
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
		private IMediator mediator;

		protected IEventStatuRepository EventStatuRepository { get; private set; }

		protected IApiEventStatuServerRequestModelValidator EventStatuModelValidator { get; private set; }

		protected IBOLEventStatuMapper BolEventStatuMapper { get; private set; }

		protected IDALEventStatuMapper DalEventStatuMapper { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStatuService(
			ILogger logger,
			IMediator mediator,
			IEventStatuRepository eventStatuRepository,
			IApiEventStatuServerRequestModelValidator eventStatuModelValidator,
			IBOLEventStatuMapper bolEventStatuMapper,
			IDALEventStatuMapper dalEventStatuMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.EventStatuRepository = eventStatuRepository;
			this.EventStatuModelValidator = eventStatuModelValidator;
			this.BolEventStatuMapper = bolEventStatuMapper;
			this.DalEventStatuMapper = dalEventStatuMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiEventStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventStatuRepository.All(limit, offset);

			return this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventStatuServerResponseModel> Get(int id)
		{
			var record = await this.EventStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventStatuMapper.MapBOToModel(this.DalEventStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventStatuServerResponseModel>> Create(
			ApiEventStatuServerRequestModel model)
		{
			CreateResponse<ApiEventStatuServerResponseModel> response = ValidationResponseFactory<ApiEventStatuServerResponseModel>.CreateResponse(await this.EventStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEventStatuMapper.MapModelToBO(default(int), model);
				var record = await this.EventStatuRepository.Create(this.DalEventStatuMapper.MapBOToEF(bo));

				var businessObject = this.DalEventStatuMapper.MapEFToBO(record);
				response.SetRecord(this.BolEventStatuMapper.MapBOToModel(businessObject));
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
				var bo = this.BolEventStatuMapper.MapModelToBO(id, model);
				await this.EventStatuRepository.Update(this.DalEventStatuMapper.MapBOToEF(bo));

				var record = await this.EventStatuRepository.Get(id);

				var businessObject = this.DalEventStatuMapper.MapEFToBO(record);
				var apiModel = this.BolEventStatuMapper.MapBOToModel(businessObject);
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

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>eaabfbb81c70f919a671190c2df6b692</Hash>
</Codenesium>*/