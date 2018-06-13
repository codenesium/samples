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
        public abstract class AbstractCustomerService: AbstractService
        {
                private ICustomerRepository customerRepository;

                private IApiCustomerRequestModelValidator customerModelValidator;

                private IBOLCustomerMapper bolCustomerMapper;

                private IDALCustomerMapper dalCustomerMapper;

                private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

                private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;

                private ILogger logger;

                public AbstractCustomerService(
                        ILogger logger,
                        ICustomerRepository customerRepository,
                        IApiCustomerRequestModelValidator customerModelValidator,
                        IBOLCustomerMapper bolCustomerMapper,
                        IDALCustomerMapper dalCustomerMapper

                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper

                        )
                        : base()

                {
                        this.customerRepository = customerRepository;
                        this.customerModelValidator = customerModelValidator;
                        this.bolCustomerMapper = bolCustomerMapper;
                        this.dalCustomerMapper = dalCustomerMapper;
                        this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
                        this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCustomerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.customerRepository.All(limit, offset, orderClause);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCustomerResponseModel> Get(int customerID)
                {
                        var record = await this.customerRepository.Get(customerID);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model)
                {
                        CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.customerModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCustomerMapper.MapModelToBO(default (int), model);
                                var record = await this.customerRepository.Create(this.dalCustomerMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int customerID,
                        ApiCustomerRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateUpdateAsync(customerID, model));

                        if (response.Success)
                        {
                                var bo = this.bolCustomerMapper.MapModelToBO(customerID, model);
                                await this.customerRepository.Update(this.dalCustomerMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int customerID)
                {
                        ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateDeleteAsync(customerID));

                        if (response.Success)
                        {
                                await this.customerRepository.Delete(customerID);
                        }

                        return response;
                }

                public async Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber)
                {
                        Customer record = await this.customerRepository.GetAccountNumber(accountNumber);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record));
                }
                public async Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID)
                {
                        List<Customer> records = await this.customerRepository.GetTerritoryID(territoryID);

                        return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0)
                {
                        List<SalesOrderHeader> records = await this.customerRepository.SalesOrderHeaders(customerID, limit, offset);

                        return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>4857e99887877af53a67e4886f57ad92</Hash>
</Codenesium>*/