using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiCustomerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber);
                Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID);

                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int customerID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ec896177d7d472b5d7ecf329a3665cbe</Hash>
</Codenesium>*/