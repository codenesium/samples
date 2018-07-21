using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IStoreService
        {
                Task<CreateResponse<ApiStoreResponseModel>> Create(
                        ApiStoreRequestModel model);

                Task<UpdateResponse<ApiStoreResponseModel>> Update(int businessEntityID,
                                                                    ApiStoreRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiStoreResponseModel> Get(int businessEntityID);

                Task<List<ApiStoreResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiStoreResponseModel>> BySalesPersonID(int? salesPersonID);

                Task<List<ApiStoreResponseModel>> ByDemographic(string demographic);

                Task<List<ApiCustomerResponseModel>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0b2c83723459290b902610f745bfca39</Hash>
</Codenesium>*/