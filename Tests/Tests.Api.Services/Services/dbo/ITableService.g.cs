using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface ITableService
        {
                Task<CreateResponse<ApiTableResponseModel>> Create(
                        ApiTableRequestModel model);

                Task<UpdateResponse<ApiTableResponseModel>> Update(int id,
                                                                    ApiTableRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTableResponseModel> Get(int id);

                Task<List<ApiTableResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>923896922888a94aeb8565f62568119e</Hash>
</Codenesium>*/