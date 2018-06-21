using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IVotesService
        {
                Task<CreateResponse<ApiVotesResponseModel>> Create(
                        ApiVotesRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiVotesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiVotesResponseModel> Get(int id);

                Task<List<ApiVotesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e5bddc03f3c510c05c277b99a28ffb2d</Hash>
</Codenesium>*/