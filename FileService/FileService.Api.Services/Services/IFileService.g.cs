using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IFileService
        {
                Task<CreateResponse<ApiFileResponseModel>> Create(
                        ApiFileRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiFileRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFileResponseModel> Get(int id);

                Task<List<ApiFileResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d3e6813523c0d61cea0162fbd449de62</Hash>
</Codenesium>*/