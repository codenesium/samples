using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractSalesPersonService: AbstractService
        {
                private ISalesPersonRepository salesPersonRepository;

                private IApiSalesPersonRequestModelValidator salesPersonModelValidator;

                private IBOLSalesPersonMapper bolSalesPersonMapper;

                private IDALSalesPersonMapper dalSalesPersonMapper;

                private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

                private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;
                private IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper;

                private IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper;
                private IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper;

                private IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper;
                private IBOLStoreMapper bolStoreMapper;

                private IDALStoreMapper dalStoreMapper;

                private ILogger logger;

                public AbstractSalesPersonService(
                        ILogger logger,
                        ISalesPersonRepository salesPersonRepository,
                        IApiSalesPersonRequestModelValidator salesPersonModelValidator,
                        IBOLSalesPersonMapper bolSalesPersonMapper,
                        IDALSalesPersonMapper dalSalesPersonMapper

                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        ,
                        IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
                        IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper
                        ,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper
                        ,
                        IBOLStoreMapper bolStoreMapper,
                        IDALStoreMapper dalStoreMapper

                        )
                        : base()

                {
                        this.salesPersonRepository = salesPersonRepository;
                        this.salesPersonModelValidator = salesPersonModelValidator;
                        this.bolSalesPersonMapper = bolSalesPersonMapper;
                        this.dalSalesPersonMapper = dalSalesPersonMapper;
                        this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
                        this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
                        this.bolSalesPersonQuotaHistoryMapper = bolSalesPersonQuotaHistoryMapper;
                        this.dalSalesPersonQuotaHistoryMapper = dalSalesPersonQuotaHistoryMapper;
                        this.bolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
                        this.dalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
                        this.bolStoreMapper = bolStoreMapper;
                        this.dalStoreMapper = dalStoreMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesPersonRepository.All(limit, offset);

                        return this.bolSalesPersonMapper.MapBOToModel(this.dalSalesPersonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesPersonResponseModel> Get(int businessEntityID)
                {
                        var record = await this.salesPersonRepository.Get(businessEntityID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesPersonMapper.MapBOToModel(this.dalSalesPersonMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
                        ApiSalesPersonRequestModel model)
                {
                        CreateResponse<ApiSalesPersonResponseModel> response = new CreateResponse<ApiSalesPersonResponseModel>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesPersonMapper.MapModelToBO(default (int), model);
                                var record = await this.salesPersonRepository.Create(this.dalSalesPersonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesPersonMapper.MapBOToModel(this.dalSalesPersonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiSalesPersonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesPersonMapper.MapModelToBO(businessEntityID, model);
                                await this.salesPersonRepository.Update(this.dalSalesPersonMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.salesPersonRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int salesPersonID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeader> records = await this.salesPersonRepository.SalesOrderHeaders(salesPersonID, limit, offset);

                        return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesPersonQuotaHistory> records = await this.salesPersonRepository.SalesPersonQuotaHistories(businessEntityID, limit, offset);

                        return this.bolSalesPersonQuotaHistoryMapper.MapBOToModel(this.dalSalesPersonQuotaHistoryMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int businessEntityID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesTerritoryHistory> records = await this.salesPersonRepository.SalesTerritoryHistories(businessEntityID, limit, offset);

                        return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiStoreResponseModel>> Stores(int salesPersonID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Store> records = await this.salesPersonRepository.Stores(salesPersonID, limit, offset);

                        return this.bolStoreMapper.MapBOToModel(this.dalStoreMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>291b5197944558fef8702bfa1617adbc</Hash>
</Codenesium>*/