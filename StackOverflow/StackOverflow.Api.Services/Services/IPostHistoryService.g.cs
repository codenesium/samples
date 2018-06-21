using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IPostHistoryService
        {
                Task<CreateResponse<ApiPostHistoryResponseModel>> Create(
                        ApiPostHistoryRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPostHistoryRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPostHistoryResponseModel> Get(int id);

                Task<List<ApiPostHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4228ec7571e99daec67ede6bbb6bef92</Hash>
</Codenesium>*/