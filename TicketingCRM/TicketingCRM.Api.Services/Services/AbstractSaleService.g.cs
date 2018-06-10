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
        public abstract class AbstractSaleService: AbstractService
        {
                private ISaleRepository saleRepository;

                private IApiSaleRequestModelValidator saleModelValidator;

                private IBOLSaleMapper bolSaleMapper;

                private IDALSaleMapper dalSaleMapper;

                private ILogger logger;

                public AbstractSaleService(
                        ILogger logger,
                        ISaleRepository saleRepository,
                        IApiSaleRequestModelValidator saleModelValidator,
                        IBOLSaleMapper bolsaleMapper,
                        IDALSaleMapper dalsaleMapper)
                        : base()

                {
                        this.saleRepository = saleRepository;
                        this.saleModelValidator = saleModelValidator;
                        this.bolSaleMapper = bolsaleMapper;
                        this.dalSaleMapper = dalsaleMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSaleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.saleRepository.All(skip, take, orderClause);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSaleResponseModel> Get(int id)
                {
                        var record = await this.saleRepository.Get(id);

                        return this.bolSaleMapper.MapBOToModel(this.dalSaleMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSaleResponseModel>> Create(
                        ApiSaleRequestModel model)
                {
                        CreateResponse<ApiSaleResponseModel> response = new CreateResponse<ApiSaleResponseModel>(await this.saleModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSaleMapper.MapModelToBO(default (int), model);
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
        }
}

/*<Codenesium>
    <Hash>26a8de5d31fdcf7a131114a643916703</Hash>
</Codenesium>*/