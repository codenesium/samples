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
        public abstract class AbstractSaleTicketsService: AbstractService
        {
                private ISaleTicketsRepository saleTicketsRepository;

                private IApiSaleTicketsRequestModelValidator saleTicketsModelValidator;

                private IBOLSaleTicketsMapper bolSaleTicketsMapper;

                private IDALSaleTicketsMapper dalSaleTicketsMapper;

                private ILogger logger;

                public AbstractSaleTicketsService(
                        ILogger logger,
                        ISaleTicketsRepository saleTicketsRepository,
                        IApiSaleTicketsRequestModelValidator saleTicketsModelValidator,
                        IBOLSaleTicketsMapper bolsaleTicketsMapper,
                        IDALSaleTicketsMapper dalsaleTicketsMapper)
                        : base()

                {
                        this.saleTicketsRepository = saleTicketsRepository;
                        this.saleTicketsModelValidator = saleTicketsModelValidator;
                        this.bolSaleTicketsMapper = bolsaleTicketsMapper;
                        this.dalSaleTicketsMapper = dalsaleTicketsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSaleTicketsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.saleTicketsRepository.All(skip, take, orderClause);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSaleTicketsResponseModel> Get(int id)
                {
                        var record = await this.saleTicketsRepository.Get(id);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
                        ApiSaleTicketsRequestModel model)
                {
                        CreateResponse<ApiSaleTicketsResponseModel> response = new CreateResponse<ApiSaleTicketsResponseModel>(await this.saleTicketsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSaleTicketsMapper.MapModelToBO(default (int), model);
                                var record = await this.saleTicketsRepository.Create(this.dalSaleTicketsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSaleTicketsRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.saleTicketsModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolSaleTicketsMapper.MapModelToBO(id, model);
                                await this.saleTicketsRepository.Update(this.dalSaleTicketsMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.saleTicketsModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.saleTicketsRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiSaleTicketsResponseModel>> GetTicketId(int ticketId)
                {
                        List<SaleTickets> records = await this.saleTicketsRepository.GetTicketId(ticketId);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>de86c99a22d261f22dbe8cbfb908752d</Hash>
</Codenesium>*/