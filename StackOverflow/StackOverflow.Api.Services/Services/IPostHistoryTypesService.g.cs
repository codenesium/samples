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

                Task<UpdateResponse<ApiPostHistoryTypesResponseModel>> Update(int id,
                                                                               ApiPostHistoryTypesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPostHistoryTypesResponseModel> Get(int id);

                Task<List<ApiPostHistoryTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5723982f651f02d021be311aa1263816</Hash>
</Codenesium>*/