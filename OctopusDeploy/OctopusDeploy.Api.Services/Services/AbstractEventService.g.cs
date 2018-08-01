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
		private IEventRepository eventRepository;

		private IApiEventRequestModelValidator eventModelValidator;

		private IBOLEventMapper bolEventMapper;

		private IDALEventMapper dalEventMapper;

		private IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper;

		private IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper;

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
			this.eventRepository = eventRepository;
			this.eventModelValidator = eventModelValidator;
			this.bolEventMapper = bolEventMapper;
			this.dalEventMapper = dalEventMapper;
			this.bolEventRelatedDocumentMapper = bolEventRelatedDocumentMapper;
			this.dalEventRelatedDocumentMapper = dalEventRelatedDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.eventRepository.All(limit, offset);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventResponseModel> Get(string id)
		{
			var record = await this.eventRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventResponseModel>> Create(
			ApiEventRequestModel model)
		{
			CreateResponse<ApiEventResponseModel> response = new CreateResponse<ApiEventResponseModel>(await this.eventModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEventMapper.MapModelToBO(default(string), model);
				var record = await this.eventRepository.Create(this.dalEventMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventResponseModel>> Update(
			string id,
			ApiEventRequestModel model)
		{
			var validationResult = await this.eventModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolEventMapper.MapModelToBO(id, model);
				await this.eventRepository.Update(this.dalEventMapper.MapBOToEF(bo));

				var record = await this.eventRepository.Get(id);

				return new UpdateResponse<ApiEventResponseModel>(this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.eventModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.eventRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiEventResponseModel>> ByAutoId(long autoId)
		{
			List<Event> records = await this.eventRepository.ByAutoId(autoId);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
		{
			List<Event> records = await this.eventRepository.ByIdRelatedDocumentIdsOccurredCategoryAutoId(id, relatedDocumentIds, occurred, category, autoId);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
		{
			List<Event> records = await this.eventRepository.ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(id, relatedDocumentIds, projectId, environmentId, category, userId, occurred, tenantId);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventResponseModel>> ByIdOccurred(string id, DateTimeOffset occurred)
		{
			List<Event> records = await this.eventRepository.ByIdOccurred(id, occurred);

			return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventRelatedDocumentResponseModel>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0)
		{
			List<EventRelatedDocument> records = await this.eventRepository.EventRelatedDocuments(eventId, limit, offset);

			return this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>12bae25e78972837c397ed7f4e264383</Hash>
</Codenesium>*/