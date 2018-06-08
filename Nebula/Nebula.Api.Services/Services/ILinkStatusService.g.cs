using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface ILinkStatusService
        {
                Task<CreateResponse<ApiLinkStatusResponseModel>> Create(
                        ApiLinkStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLinkStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLinkStatusResponseModel> Get(int id);

                Task<List<ApiLinkStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>1cfcbed8d3a26d2f0d59ce9bc6b35f7c</Hash>
</Codenesium>*/