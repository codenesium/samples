using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IChainService
        {
                Task<CreateResponse<ApiChainResponseModel>> Create(
                        ApiChainRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiChainRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiChainResponseModel> Get(int id);

                Task<List<ApiChainResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>cc0bcaed30b8f6fefe6244568ee8e584</Hash>
</Codenesium>*/