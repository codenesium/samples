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

                Task<List<ApiPasswordResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e58c3a45b0124c219a85de2a994d7fd3</Hash>
</Codenesium>*/