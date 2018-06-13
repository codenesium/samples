using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IStoreService
        {
                Task<CreateResponse<ApiStoreResponseModel>> Create(
                        ApiStoreRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiStoreRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiStoreResponseModel> Get(int businessEntityID);

                Task<List<ApiStoreResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiStoreResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID);
                Task<List<ApiStoreResponseModel>> GetDemographics(string demographics);

                Task<List<ApiCustomerResponseModel>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f843a02642738b6d59ed0f01573d4624</Hash>
</Codenesium>*/