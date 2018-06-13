using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPasswordService
        {
                Task<CreateResponse<ApiPasswordResponseModel>> Create(
                        ApiPasswordRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiPasswordRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPasswordResponseModel> Get(int businessEntityID);

                Task<List<ApiPasswordResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e8330948f76239732fac9081cad5d3da</Hash>
</Codenesium>*/