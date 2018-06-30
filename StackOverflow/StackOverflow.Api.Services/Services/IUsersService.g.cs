using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IUsersService
        {
                Task<CreateResponse<ApiUsersResponseModel>> Create(
                        ApiUsersRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiUsersRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiUsersResponseModel> Get(int id);

                Task<List<ApiUsersResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7a40fd7a5d1645698bcb9468740a57c8</Hash>
</Codenesium>*/