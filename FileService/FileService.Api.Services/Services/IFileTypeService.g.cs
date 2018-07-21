using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public interface IFileTypeService
        {
                Task<CreateResponse<ApiFileTypeResponseModel>> Create(
                        ApiFileTypeRequestModel model);

                Task<UpdateResponse<ApiFileTypeResponseModel>> Update(int id,
                                                                       ApiFileTypeRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFileTypeResponseModel> Get(int id);

                Task<List<ApiFileTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiFileResponseModel>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>85de5e5e204765372ee5392ba8d4bc31</Hash>
</Codenesium>*/