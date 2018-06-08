using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public interface IDeviceService
        {
                Task<CreateResponse<ApiDeviceResponseModel>> Create(
                        ApiDeviceRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiDeviceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDeviceResponseModel> Get(int id);

                Task<List<ApiDeviceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiDeviceResponseModel> GetPublicId(Guid publicId);
        }
}

/*<Codenesium>
    <Hash>fd48c64b177465afcfc3c3a3311764b1</Hash>
</Codenesium>*/