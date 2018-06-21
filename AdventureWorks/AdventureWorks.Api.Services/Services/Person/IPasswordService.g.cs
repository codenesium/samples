using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>77183cf20318a24218531c877c5c5ccc</Hash>
</Codenesium>*/