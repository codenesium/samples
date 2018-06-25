using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractEventService : AbstractService
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
                        IBOLEventMapper bolEventMapper,
                        IDALEventMapper dalEventMapper)
                        : base()
                {
                        this.eventRepository = eventRepository;
                        this.eventModelValidator = eventModelValidator;
                        this.bolEventMapper = bolEventMapper;
                        this.dalEventMapper = dalEventMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiEventResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.eventRepository.All(limit, offset);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiEventResponseModel> Get(int id)
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
                                var bo = this.bolEventMapper.MapModelToBO(default(int), model);
                                var record = await this.eventRepository.Create(this.dalEventMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
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
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.eventModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.eventRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiEventResponseModel>> ByCityId(int cityId)
                {
                        List<Event> records = await this.eventRepository.ByCityId(cityId);

                        return this.bolEventMapper.MapBOToModel(this.dalEventMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>36dd07032a76f9b92da4779c36d26a25</Hash>
</Codenesium>*/