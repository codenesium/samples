using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICustomerService
        {
                Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model);

                Task<ActionResponse> Update(int customerID,
                                            ApiCustomerRequestModel model);

                Task<ActionResponse> Delete(int customerID);

                Task<ApiCustomerResponseModel> Get(int customerID);

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCustomerResponseModel> ByAccountNumber(string accountNumber);

                Task<List<ApiCustomerResponseModel>> ByTerritoryID(int? territoryID);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>61a75b05ff1a377ea61265507ba02790</Hash>
</Codenesium>*/