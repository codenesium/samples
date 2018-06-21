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
        public abstract class AbstractEventRelatedDocumentService : AbstractService
        {
                private IEventRelatedDocumentRepository eventRelatedDocumentRepository;

                private IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator;

                private IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper;

                private IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper;

                private ILogger logger;

                public AbstractEventRelatedDocumentService(
                        ILogger logger,
                        IEventRelatedDocumentRepository eventRelatedDocumentRepository,
                        IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator,
                        IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
                        IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper)
                        : base()
                {
                        this.eventRelatedDocumentRepository = eventRelatedDocumentRepository;
                        this.eventRelatedDocumentModelValidator = eventRelatedDocumentModelValidator;
                        this.bolEventRelatedDocumentMapper = bolEventRelatedDocumentMapper;
                        this.dalEventRelatedDocumentMapper = dalEventRelatedDocumentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.eventRelatedDocumentRepository.All(limit, offset);

                        return this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEventRelatedDocumentResponseModel> Get(int id)
                {
                        var record = await this.eventRelatedDocumentRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> Create(
                        ApiEventRelatedDocumentRequestModel model)
                {
                        CreateResponse<ApiEventRelatedDocumentResponseModel> response = new CreateResponse<ApiEventRelatedDocumentResponseModel>(await this.eventRelatedDocumentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolEventRelatedDocumentMapper.MapModelToBO(default(int), model);
                                var record = await this.eventRelatedDocumentRepository.Create(this.dalEventRelatedDocumentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiEventRelatedDocumentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.eventRelatedDocumentModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolEventRelatedDocumentMapper.MapModelToBO(id, model);
                                await this.eventRelatedDocumentRepository.Update(this.dalEventRelatedDocumentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.eventRelatedDocumentModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.eventRelatedDocumentRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventId(string eventId)
                {
                        List<EventRelatedDocument> records = await this.eventRelatedDocumentRepository.GetEventId(eventId);

                        return this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(records));
                }

                public async Task<List<ApiEventRelatedDocumentResponseModel>> GetEventIdRelatedDocumentId(string eventId, string relatedDocumentId)
                {
                        List<EventRelatedDocument> records = await this.eventRelatedDocumentRepository.GetEventIdRelatedDocumentId(eventId, relatedDocumentId);

                        return this.bolEventRelatedDocumentMapper.MapBOToModel(this.dalEventRelatedDocumentMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>bf23660a723373fd91b076be88c65c2c</Hash>
</Codenesium>*/