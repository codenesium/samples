using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface ICommentsService
        {
                Task<CreateResponse<ApiCommentsResponseModel>> Create(
                        ApiCommentsRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCommentsRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCommentsResponseModel> Get(int id);

                Task<List<ApiCommentsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d29826f5f66ad0ac55a97e47b1b6bd3a</Hash>
</Codenesium>*/