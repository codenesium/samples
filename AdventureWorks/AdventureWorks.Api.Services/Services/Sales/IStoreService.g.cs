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

                Task<List<ApiStoreResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiStoreResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID);
                Task<List<ApiStoreResponseModel>> GetDemographics(string demographics);
        }
}

/*<Codenesium>
    <Hash>9b6d20ff23f7e041018b88432801eba5</Hash>
</Codenesium>*/