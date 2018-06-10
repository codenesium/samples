using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractTicketStatusService: AbstractService
        {
                private ITicketStatusRepository ticketStatusRepository;

                private IApiTicketStatusRequestModelValidator ticketStatusModelValidator;

                private IBOLTicketStatusMapper bolTicketStatusMapper;

                private IDALTicketStatusMapper dalTicketStatusMapper;

                private ILogger logger;

                public AbstractTicketStatusService(
                        ILogger logger,
                        ITicketStatusRepository ticketStatusRepository,
                        IApiTicketStatusRequestModelValidator ticketStatusModelValidator,
                        IBOLTicketStatusMapper bolticketStatusMapper,
                        IDALTicketStatusMapper dalticketStatusMapper)
                        : base()

                {
                        this.ticketStatusRepository = ticketStatusRepository;
                        this.ticketStatusModelValidator = ticketStatusModelValidator;
                        this.bolTicketStatusMapper = bolticketStatusMapper;
                        this.dalTicketStatusMapper = dalticketStatusMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTicketStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.ticketStatusRepository.All(skip, take, orderClause);

                        return this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTicketStatusResponseModel> Get(int id)
                {
                        var record = await this.ticketStatusRepository.Get(id);

                        return this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
                        ApiTicketStatusRequestModel model)
                {
                        CreateResponse<ApiTicketStatusResponseModel> response = new CreateResponse<ApiTicketStatusResponseModel>(await this.ticketStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTicketStatusMapper.MapModelToBO(default (int), model);
                                var record = await this.ticketStatusRepository.Create(this.dalTicketStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTicketStatusMapper.MapBOToModel(this.dalTicketStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTicketStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.ticketStatusModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTicketStatusMapper.MapModelToBO(id, model);
                                await this.ticketStatusRepository.Update(this.dalTicketStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.ticketStatusModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.ticketStatusRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d38c92e614c1434c1b7a52a1f0bc7266</Hash>
</Codenesium>*/