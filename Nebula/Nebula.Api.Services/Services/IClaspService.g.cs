using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>d42ef1dcbc39f6755f05d15d579e9782</Hash>
</Codenesium>*/