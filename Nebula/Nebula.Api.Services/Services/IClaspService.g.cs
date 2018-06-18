using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IClaspService
        {
                Task<CreateResponse<ApiClaspResponseModel>> Create(
                        ApiClaspRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiClaspRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiClaspResponseModel> Get(int id);

                Task<List<ApiClaspResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>678ef1c20f226b404b8db5c452475957</Hash>
</Codenesium>*/