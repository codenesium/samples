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

                private ILogger logger;

                public AbstractEventService(
                        ILogger logger,
                        IEventRepository eventRepository,
                        IApiEventRequestModelValidator eventModelValidator,
                        IBOLEventMapper boleventMapper,
                        IDALEventMapper daleventMapper)
                        : base()

                {
                        this.eventRepository = eventRepository;
                        this.eventModelValidator = eventModelValidator;
                        this.bolEventMapper = boleventMapper;
                        this.dalEventMapper = daleventMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEventResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.eventRepository.All(skip, take, orderClause);

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
                public async Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTime occurred, string category, long autoId)
                {
                        List<Event> records = await this.eventRepository.GetIdRelatedDocumentIdsOccurredCategoryAutoId(id, relatedDocumentIds, occurred, category, autoId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEventResponseModel>> GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTime occurred, string tenantId)
                {
                        List<Event> records = await this.eventRepository.GetIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(id, relatedDocumentIds, projectId, environmentId, category, userId, occurred, tenantId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
                public async Task<List<ApiEventResponseModel>> GetIdOccurred(string id, DateTime occurred)
                {
                        List<Event> records = await this.eventRepository.GetIdOccurred(id, occurred);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>70ea39443cf3a8ebbaa7728ff1bbda98</Hash>
</Codenesium>*/