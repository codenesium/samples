using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IFileTypeService
        {
                Task<CreateResponse<ApiFileTypeResponseModel>> Create(
                        ApiFileTypeRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiFileTypeRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiFileTypeResponseModel> Get(int id);

                Task<List<ApiFileTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiFileResponseModel>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>dbac4e3c58bc578492c36b10829ce677</Hash>
</Codenesium>*/