using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IPostLinksService
        {
                Task<CreateResponse<ApiPostLinksResponseModel>> Create(
                        ApiPostLinksRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPostLinksRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPostLinksResponseModel> Get(int id);

                Task<List<ApiPostLinksResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f21b70e9997d1a0f443cb9466d28829a</Hash>
</Codenesium>*/