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
        public abstract class AbstractTicketService: AbstractService
        {
                private ITicketRepository ticketRepository;

                private IApiTicketRequestModelValidator ticketModelValidator;

                private IBOLTicketMapper bolTicketMapper;

                private IDALTicketMapper dalTicketMapper;

                private IBOLSaleTicketsMapper bolSaleTicketsMapper;

                private IDALSaleTicketsMapper dalSaleTicketsMapper;

                private ILogger logger;

                public AbstractTicketService(
                        ILogger logger,
                        ITicketRepository ticketRepository,
                        IApiTicketRequestModelValidator ticketModelValidator,
                        IBOLTicketMapper bolTicketMapper,
                        IDALTicketMapper dalTicketMapper

                        ,
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper

                        )
                        : base()

                {
                        this.ticketRepository = ticketRepository;
                        this.ticketModelValidator = ticketModelValidator;
                        this.bolTicketMapper = bolTicketMapper;
                        this.dalTicketMapper = dalTicketMapper;
                        this.bolSaleTicketsMapper = bolSaleTicketsMapper;
                        this.dalSaleTicketsMapper = dalSaleTicketsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTicketResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.ticketRepository.All(limit, offset, orderClause);

                        return this.bolTicketMapper.MapBOToModel(this.dalTicketMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiTicketResponseModel> Get(int id)
                {
                        var record = await this.ticketRepository.Get(id);

                        return this.bolTicketMapper.MapBOToModel(this.dalTicketMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiTicketResponseModel>> Create(
                        ApiTicketRequestModel model)
                {
                        CreateResponse<ApiTicketResponseModel> response = new CreateResponse<ApiTicketResponseModel>(await this.ticketModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolTicketMapper.MapModelToBO(default (int), model);
                                var record = await this.ticketRepository.Create(this.dalTicketMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolTicketMapper.MapBOToModel(this.dalTicketMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiTicketRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.ticketModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolTicketMapper.MapModelToBO(id, model);
                                await this.ticketRepository.Update(this.dalTicketMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.ticketModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.ticketRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiTicketResponseModel>> GetTicketStatusId(int ticketStatusId)
                {
                        List<Ticket> records = await this.ticketRepository.GetTicketStatusId(ticketStatusId);

                        return this.bolTicketMapper.MapBOToModel(this.dalTicketMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0)
                {
                        List<SaleTickets> records = await this.ticketRepository.SaleTickets(ticketId, limit, offset);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>e999c17b91737a957ea5f90a1ac93d17</Hash>
</Codenesium>*/