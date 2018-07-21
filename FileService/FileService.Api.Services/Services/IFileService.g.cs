using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public interface IFileService
        {
                Task<CreateResponse<ApiFileResponseModel>> Create(
                        ApiFileRequestModel model);

                Task<UpdateResponse<ApiFileResponseModel>> Update(int id,
                                                                   ApiFileRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFileResponseModel> Get(int id);

                Task<List<ApiFileResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e20e55025b3444f2f0eeb4ec06ade305</Hash>
</Codenesium>*/