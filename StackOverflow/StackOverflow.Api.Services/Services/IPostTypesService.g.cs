using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IPostTypesService
        {
                Task<CreateResponse<ApiPostTypesResponseModel>> Create(
                        ApiPostTypesRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPostTypesRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPostTypesResponseModel> Get(int id);

                Task<List<ApiPostTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ca28a90e4f5254b7bf274c18122954c0</Hash>
</Codenesium>*/