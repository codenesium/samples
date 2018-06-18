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

                Task<List<ApiStoreResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiStoreResponseModel>> BySalesPersonID(Nullable<int> salesPersonID);
                Task<List<ApiStoreResponseModel>> ByDemographics(string demographics);

                Task<List<ApiCustomerResponseModel>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>280c573d95c557744628cb5b53ef4f42</Hash>
</Codenesium>*/