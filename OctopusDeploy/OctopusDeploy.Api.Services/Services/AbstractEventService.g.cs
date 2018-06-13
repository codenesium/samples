using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractEventService: AbstractService
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
                        IDALEventMapper dalEventMapper

                        ,
                        IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper

                        )
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

                public virtual async Task<List<ApiEventResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.eventRepository.All(limit, offset, orderClause);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEventResponseModel> Get(string id)
                {
                        var record = await this.eventRepository.Get(id);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiEventResponseModel>> Create(
                        ApiEventRequestModel model)
                {
                        CreateResponse<ApiEventResponseModel> response = new CreateResponse<ApiEventResponseModel>(await this.eventModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolEventMapper.MapModelToBO(default (string), model);
                                var record = await this.eventRepository.Create(this.dalEventMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiEventRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.eventModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolEventMapper.MapModelToBO(id, model);
                                await this.eventRepository.Update(this.dalEventMapper.MapBOToEF(bo));
                        }

                        return response;
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

                public async Task<List<ApiEventResponseModel>> GetAutoId(long autoId)
                {
                        List<Event> records = await this.eventRepository.GetAutoId(autoId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId)
                {
                        List<Event> records = await this.eventRepository.GetIdRelatedDocumentIdsOccurredCategoryAutoId(id, relatedDocumentIds, occurred, category, autoId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId)
                {
                        List<Event> records = await this.eventRepository.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(id, relatedDocumentIds, projectId, environmentId, category, userId, occurred, tenantId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEventResponseModel>> GetIdOccurred(string id, DateTimeOffset occurred)
                {
                        List<Event> records = await this.eventRepository.GetIdOccurred(id, occurred);

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
    <Hash>9c79520b4f827f2d44644aca5384fb46</Hash>
</Codenesium>*/