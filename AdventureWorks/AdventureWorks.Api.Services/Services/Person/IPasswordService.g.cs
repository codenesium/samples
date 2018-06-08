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

                Task<List<ApiPasswordResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6fea3e426c09b139c7e7a8053d91e3bb</Hash>
</Codenesium>*/