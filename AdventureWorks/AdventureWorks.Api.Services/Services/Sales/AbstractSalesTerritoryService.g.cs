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
        public abstract class AbstractSalesTerritoryService: AbstractService
        {
                private ISalesTerritoryRepository salesTerritoryRepository;

                private IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator;

                private IBOLSalesTerritoryMapper bolSalesTerritoryMapper;

                private IDALSalesTerritoryMapper dalSalesTerritoryMapper;

                private IBOLCustomerMapper bolCustomerMapper;

                private IDALCustomerMapper dalCustomerMapper;
                private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

                private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;
                private IBOLSalesPersonMapper bolSalesPersonMapper;

                private IDALSalesPersonMapper dalSalesPersonMapper;
                private IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper;

                private IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper;

                private ILogger logger;

                public AbstractSalesTerritoryService(
                        ILogger logger,
                        ISalesTerritoryRepository salesTerritoryRepository,
                        IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
                        IBOLSalesTerritoryMapper bolSalesTerritoryMapper,
                        IDALSalesTerritoryMapper dalSalesTerritoryMapper

                        ,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper
                        ,
                        IBOLSalesPersonMapper bolSalesPersonMapper,
                        IDALSalesPersonMapper dalSalesPersonMapper
                        ,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper

                        )
                        : base()

                {
                        this.salesTerritoryRepository = salesTerritoryRepository;
                        this.salesTerritoryModelValidator = salesTerritoryModelValidator;
                        this.bolSalesTerritoryMapper = bolSalesTerritoryMapper;
                        this.dalSalesTerritoryMapper = dalSalesTerritoryMapper;
                        this.bolCustomerMapper = bolCustomerMapper;
                        this.dalCustomerMapper = dalCustomerMapper;
                        this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
                        this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
                        this.bolSalesPersonMapper = bolSalesPersonMapper;
                        this.dalSalesPersonMapper = dalSalesPersonMapper;
                        this.bolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
                        this.dalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiSalesTerritoryResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.salesTerritoryRepository.All(limit, offset, orderClause);

                        return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> Get(int territoryID)
                {
                        var record = await this.salesTerritoryRepository.Get(territoryID);

                        return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
                        ApiSalesTerritoryRequestModel model)
                {
                        CreateResponse<ApiSalesTerritoryResponseModel> response = new CreateResponse<ApiSalesTerritoryResponseModel>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesTerritoryMapper.MapModelToBO(default (int), model);
                                var record = await this.salesTerritoryRepository.Create(this.dalSalesTerritoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int territoryID,
                        ApiSalesTerritoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model));

                        if (response.Success)
                        {
                                var bo = this.bolSalesTerritoryMapper.MapModelToBO(territoryID, model);
                                await this.salesTerritoryRepository.Update(this.dalSalesTerritoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int territoryID)
                {
                        ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateDeleteAsync(territoryID));

                        if (response.Success)
                        {
                                await this.salesTerritoryRepository.Delete(territoryID);
                        }

                        return response;
                }

                public async Task<ApiSalesTerritoryResponseModel> GetName(string name)
                {
                        SalesTerritory record = await this.salesTerritoryRepository.GetName(name);

                        return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record));
                }

                public async virtual Task<List<ApiCustomerResponseModel>> Customers(int territoryID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Customer> records = await this.salesTerritoryRepository.Customers(territoryID, limit, offset);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int territoryID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeader> records = await this.salesTerritoryRepository.SalesOrderHeaders(territoryID, limit, offset);

                        return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSalesPersonResponseModel>> SalesPersons(int territoryID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesPerson> records = await this.salesTerritoryRepository.SalesPersons(territoryID, limit, offset);

                        return this.bolSalesPersonMapper.MapBOToModel(this.dalSalesPersonMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int territoryID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesTerritoryHistory> records = await this.salesTerritoryRepository.SalesTerritoryHistories(territoryID, limit, offset);

                        return this.bolSalesTerritoryHistoryMapper.MapBOToModel(this.dalSalesTerritoryHistoryMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b422ae097cb3fb2ca95b42a2407a8fd3</Hash>
</Codenesium>*/