using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractSalesTerritoryService : AbstractService
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
                        IDALSalesTerritoryMapper dalSalesTerritoryMapper,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
                        IBOLSalesPersonMapper bolSalesPersonMapper,
                        IDALSalesPersonMapper dalSalesPersonMapper,
                        IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
                        IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper)
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

                public virtual async Task<List<ApiSalesTerritoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.salesTerritoryRepository.All(limit, offset);

                        return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiSalesTerritoryResponseModel> Get(int territoryID)
                {
                        var record = await this.salesTerritoryRepository.Get(territoryID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
                        ApiSalesTerritoryRequestModel model)
                {
                        CreateResponse<ApiSalesTerritoryResponseModel> response = new CreateResponse<ApiSalesTerritoryResponseModel>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolSalesTerritoryMapper.MapModelToBO(default(int), model);
                                var record = await this.salesTerritoryRepository.Create(this.dalSalesTerritoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiSalesTerritoryResponseModel>> Update(
                        int territoryID,
                        ApiSalesTerritoryRequestModel model)
                {
                        var validationResult = await this.salesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolSalesTerritoryMapper.MapModelToBO(territoryID, model);
                                await this.salesTerritoryRepository.Update(this.dalSalesTerritoryMapper.MapBOToEF(bo));

                                var record = await this.salesTerritoryRepository.Get(territoryID);

                                return new UpdateResponse<ApiSalesTerritoryResponseModel>(this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiSalesTerritoryResponseModel>(validationResult);
                        }
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

                public async Task<ApiSalesTerritoryResponseModel> ByName(string name)
                {
                        SalesTerritory record = await this.salesTerritoryRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolSalesTerritoryMapper.MapBOToModel(this.dalSalesTerritoryMapper.MapEFToBO(record));
                        }
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
    <Hash>3274db2d3f79cbbf6b877a16e3467151</Hash>
</Codenesium>*/