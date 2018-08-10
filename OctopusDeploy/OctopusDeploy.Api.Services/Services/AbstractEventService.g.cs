using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractEventService : AbstractService
	{
		protected IEventRepository EventRepository { get; private set; }

		protected IApiEventRequestModelValidator EventModelValidator { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		protected IBOLEventRelatedDocumentMapper BolEventRelatedDocumentMapper { get; private set; }

		protected IDALEventRelatedDocumentMapper DalEventRelatedDocumentMapper { get; private set; }

		private ILogger logger;

		public AbstractEventService(
			ILogger logger,
			IEventRepository eventRepository,
			IApiEventRequestModelValidator eventModelValidator,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper,
			IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
			IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper)
			: base()
		{
			this.EventRepository = eventRepository;
			this.EventModelValidator = eventModelValidator;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.BolEventRelatedDocumentMapper = bolEventRelatedDocumentMapper;
			this.DalEventRelatedDocumentMapper = dalEventRelatedDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventRepository.All(limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventResponseModel> Get(string id)
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

		public virtual async Task<CreateResponse<ApiEventResponseModel>> Create(
			ApiEventRequestModel model)
		{
			CreateResponse<ApiEventResponseModel> response = new CreateResponse<ApiEventResponseModel>(await this.EventModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventMapper.MapModelToBO(default(string), model);
				var record = await this.EventRepository.Create(this.DalEventMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> Update(
			string id,
			ApiEventRequestModel model)
		{
			var validationResult = await this.EventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventMapper.MapModelToBO(id, model);
				await this.EventRepository.Update(this.DalEventMapper.MapBOToEF(bo));

				var record = await this.EventRepository.Get(id);

				return new UpdateResponse<ApiEventResponseModel>(this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.EventModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EventRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiEventResponseModel>> ByAutoId(long autoId)
		{
			List<Event> records = await this.EventRepository.ByAutoId(autoId);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
		{
			List<Event> records = await this.EventRepository.ByIdRelatedDocumentIdsOccurredCategoryAutoId(id, relatedDocumentIds, occurred, category, autoId);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
		{
			List<Event> records = await this.EventRepository.ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(id, relatedDocumentIds, projectId, environmentId, category, userId, occurred, tenantId);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdOccurred(string id, DateTimeOffset occurred)
		{
			List<Event> records = await this.EventRepository.ByIdOccurred(id, occurred);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventRelatedDocument> records = await this.EventRepository.EventRelatedDocuments(eventId, limit, offset);

			return this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6bee29d5b96f5b1d033cb8fd9f50ef5d</Hash>
</Codenesium>*/