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

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiStoreRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiStoreResponseModel> Get(int businessEntityID);

                Task<List<ApiStoreResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiStoreResponseModel>> BySalesPersonID(int? salesPersonID);

                Task<List<ApiStoreResponseModel>> ByDemographics(string demographics);

                Task<List<ApiCustomerResponseModel>> Customers(int storeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d29a479b5d7b59f922605f6c75e96480</Hash>
</Codenesium>*/