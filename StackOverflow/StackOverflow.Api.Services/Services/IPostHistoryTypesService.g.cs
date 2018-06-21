using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IPostHistoryTypesService
        {
                Task<CreateResponse<ApiPostHistoryTypesResponseModel>> Create(
                        ApiPostHistoryTypesRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPostHistoryTypesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPostHistoryTypesResponseModel> Get(int id);

                Task<List<ApiPostHistoryTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>97c6423db44ed5c00b4e84dfc802329b</Hash>
</Codenesium>*/