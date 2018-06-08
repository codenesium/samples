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

                Task<List<ApiFileTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>eb6abf183a35b0ede08f6ccb847101f5</Hash>
</Codenesium>*/