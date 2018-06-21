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
        public abstract class AbstractSaleService : AbstractService
        {
                private ISaleRepository saleRepository;

                private IApiSaleRequestModelValidator saleModelValidator;

                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private IBOLSaleTicketsMapper bolSaleTicketsMapper;

                private IDALSaleTicketsMapper dalSaleTicketsMapper;

                private ILogger logger;

                public AbstractSaleService(
                        ILogger logger,
                        ISaleRepository saleRepository,
                        IApiSaleRequestModelValidator saleModelValidator,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper,
                        IBOLSaleTicketsMapper bolSaleTicketsMapper,
                        IDALSaleTicketsMapper dalSaleTicketsMapper)
                        : base()
                {
                        this.saleRepository = saleRepository;
                        this.saleModelValidator = saleModelValidator;
                        this.bolSaleMapper = bolSaleMapper;
                        this.dalSaleMapper = dalSaleMapper;
                        this.bolSaleTicketsMapper = bolSaleTicketsMapper;
                        this.dalSaleTicketsMapper = dalSaleTicketsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSaleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.saleRepository.All(limit, offset);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSaleResponseModel> Get(int id)
                {
                        var record = await this.saleRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
                        ApiSaleRequestModel model)
                {
                        CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.saleModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSaleMapper.MapModelToBO(default(int), model);
                                var record = await this.saleRepository.Create(this.dalSaleMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiSaleRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolSaleMapper.MapModelToBO(id, model);
                                await this.saleRepository.Update(this.dalSaleMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.saleModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.saleRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiSaleResponseModel>> GetTransactionId(int transactionId)
                {
                        List<Sale> records = await this.saleRepository.GetTransactionId(transactionId);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0)
                {
                        List<SaleTickets> records = await this.saleRepository.SaleTickets(saleId, limit, offset);

                        return this.bolSaleTicketsMapper.MapBOToModel(this.dalSaleTicketsMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>07c44f6e6d8f5e818bcb82c43ff902a6</Hash>
</Codenesium>*/