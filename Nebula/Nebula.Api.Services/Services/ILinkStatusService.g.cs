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

                Task<List<ApiLinkStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a14595a56f0ff8b2f8c36405d9499760</Hash>
</Codenesium>*/