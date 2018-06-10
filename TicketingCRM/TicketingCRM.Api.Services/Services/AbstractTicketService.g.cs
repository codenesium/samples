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

                private ILogger logger;

                public AbstractTicketService(
                        ILogger logger,
                        ITicketRepository ticketRepository,
                        IApiTicketRequestModelValidator ticketModelValidator,
                        IBOLTicketMapper bolticketMapper,
                        IDALTicketMapper dalticketMapper)
                        : base()

                {
                        this.ticketRepository = ticketRepository;
                        this.ticketModelValidator = ticketModelValidator;
                        this.bolTicketMapper = bolticketMapper;
                        this.dalTicketMapper = dalticketMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiTicketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.ticketRepository.All(skip, take, orderClause);

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
        }
}

/*<Codenesium>
    <Hash>472f20485914b845f049f424955f39c4</Hash>
</Codenesium>*/