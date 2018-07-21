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
        public abstract class AbstractSaleTicketsService : AbstractService
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
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper)
                        : base()
                {
                        this.saleTicketsRepository = saleTicketsRepository;
                        this.saleTicketsModelValidator = saleTicketsModelValidator;
                        this.bolSaleTicketsMapper = bolSaleTicketsMapper;
                        this.dalSaleTicketsMapper = dalSaleTicketsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSaleTicketsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.saleTicketsRepository.All(limit, offset);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSaleTicketsResponseModel> Get(int id)
                {
                        var record = await this.saleTicketsRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
                        ApiSaleTicketsRequestModel model)
                {
                        CreateResponse<ApiSaleTicketsResponseModel> response = new CreateResponse<ApiSaleTicketsResponseModel>(await this.saleTicketsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSaleTicketsMapper.MapModelToBO(default(int), model);
                                var record = await this.saleTicketsRepository.Create(this.dalSaleTicketsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSaleTicketsResponseModel>> Update(
                        int id,
                        ApiSaleTicketsRequestModel model)
                {
                        var validationResult = await this.saleTicketsModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSaleTicketsMapper.MapModelToBO(id, model);
                                await this.saleTicketsRepository.Update(this.dalSaleTicketsMapper.MapBOToEF(bo));

                                var record = await this.saleTicketsRepository.Get(id);

                                return new UpdateResponse<ApiSaleTicketsResponseModel>(this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSaleTicketsResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiSaleTicketsResponseModel>> ByTicketId(int ticketId)
                {
                        List<SaleTickets> records = await this.saleTicketsRepository.ByTicketId(ticketId);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>02137cd4bd14a7f48b5b270b0b62e732</Hash>
</Codenesium>*/